using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Singleton interface.
	private static GameManager _instance = null;
	public static GameManager Instance => _instance;

	[SerializeField]
	private Player _playerInstance;

    [SerializeField]
    private GameObject _camera;


    void Start()
	{
		if (_instance != null)
		{
			Debug.LogWarning("An instance of GameManager is already present in the scene.");
			return;
		}

		_instance = this;
	}

	void OnDestroy()
	{
		_instance = null;
	}


	public Player GetPlayer()
	{
		return _playerInstance;
	}

    public GameObject GetPlayerCamera()
    {
        return _camera;
    }
}
