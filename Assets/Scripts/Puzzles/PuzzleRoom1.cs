using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleRoom1 : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsInOrder;

    [SerializeField] private XRSocketInteractor[] _socketsInOrder;

    private GameObject[] _currentObjects;


    public UnityEvent OnSolve;
    

    // Start is called before the first frame update
    void Start()
    {
        _currentObjects = new GameObject[_socketsInOrder.Length];

        _socketsInOrder[0].selectEntered.AddListener((args) => { OnAttach(0, args); });
        _socketsInOrder[1].selectEntered.AddListener((args) => { OnAttach(1, args); });
        _socketsInOrder[2].selectEntered.AddListener((args) => { OnAttach(2, args); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CheckObjects()
    {
        bool good = true;
        for (int i = 0; i < _currentObjects.Length; i++)
        {
            if (_currentObjects[i] != _objectsInOrder[i])
            {
                good = false;
                break;
            }
        }

        if (good)
        {
            OnSolve.Invoke();
        }
    }

    private void OnAttach(int i, SelectEnterEventArgs args)
    {
        _currentObjects[i] = args.interactable.gameObject;

        CheckObjects();
    }
}
