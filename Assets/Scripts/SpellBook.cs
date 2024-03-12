using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SpellBook : MonoBehaviour
{
    [SerializeField]
    private Skill _skillClass;

    [SerializeReference]
    private GameObject _disappearParticles;

    private XRGrabInteractable _interactable;

    public UnityEvent OnUnlock;


    // Start is called before the first frame update
    void Start()
    {
        _interactable = GetComponent<XRGrabInteractable>();
        if (_interactable != null)
        {
            _interactable.selectEntered.AddListener(OnGrab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnGrab(SelectEnterEventArgs args)
    {
        StartCoroutine(AcquireSpell());
    }

    private IEnumerator AcquireSpell()
    {
        yield return new WaitForSeconds(0.6F);

        if (_skillClass != null) GameManager.Instance.GetPlayer().UnlockSkill(_skillClass);
        OnUnlock.Invoke();

        Instantiate(_disappearParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
