using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellInputController : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] InputActionReference _leftIndexValue;
    [SerializeField] InputActionReference _rightIndexValue;

    [SerializeField] bool _isLeftHand;


    private void Start()
    {
        _leftIndexValue.action.started += ActionLeft_started;
        _rightIndexValue.action.started += ActionLeft_started;

        _leftIndexValue.action.canceled += ActionLeft_canceled;
        _rightIndexValue.action.canceled += ActionLeft_canceled;
    }


    private void OnDestroy()
    {
        _leftIndexValue.action.started -= ActionLeft_started;
        _rightIndexValue.action.started -= ActionLeft_started;

        _leftIndexValue.action.canceled -= ActionLeft_canceled;
        _rightIndexValue.action.canceled -= ActionLeft_canceled;
    }

    private void ActionLeft_started(InputAction.CallbackContext obj)
    {
        if (!_isLeftHand) return;

        foreach (Skill s in _player.Skills)
        {
            //s.SpellSphere(_player);
        }
    }

    private void ActionLeft_canceled(InputAction.CallbackContext obj)
    {
        if (!_isLeftHand) return;

        foreach (Skill s in _player.Skills)
        {
            s.SimpleActivate(_player);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
