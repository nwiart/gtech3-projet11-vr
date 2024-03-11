using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingToggle : MonoBehaviour
{
	[SerializeField]
	private GameObject _optionGrab;

	[SerializeField]
	private Material[] _materialsOn;

	[SerializeField]
	private Material[] _materialsOff;

	[SerializeField]
	private float _buttonAppearDelay = 2.0F;

	[SerializeField]
	private bool _initialState = false;


	[SerializeField]
	public UnityEvent OnToggle;

	[SerializeField]
	public UnityEvent OnEnable;

	[SerializeField]
	public UnityEvent OnDisable;


	private MeshRenderer _meshRenderer;

	bool _state;


	void Start()
	{
		_meshRenderer = _optionGrab.GetComponent<MeshRenderer>();

		_state = _initialState;
		if (_state) OnEnable.Invoke(); else OnDisable.Invoke();

		UpdateMaterials();
	}

	void Update()
	{
		_optionGrab.transform.localPosition = new Vector3(0.0F, Mathf.Sin(Time.time) * 0.05F, 0.0F);

		GameObject cam = GameManager.Instance.GetPlayerCamera();
		if (cam != null)
		{
			Vector3 dir = cam.transform.position - transform.position;
			dir.y = 0;
			transform.rotation = Quaternion.LookRotation(dir);
		}
	}


	public void Toggle()
	{
		StartCoroutine(DoToggleAnim());
	}

	private IEnumerator DoToggleAnim()
	{
		_optionGrab.SetActive(false);

		_state = !_state;

		OnToggle.Invoke();
		if (_state) OnEnable.Invoke(); else OnDisable.Invoke();

		yield return new WaitForSeconds(_buttonAppearDelay);

		_optionGrab.SetActive(true);

		UpdateMaterials();
	}


	private void UpdateMaterials()
	{
		_meshRenderer.materials = (_state ? _materialsOn : _materialsOff); ;
	}
}
