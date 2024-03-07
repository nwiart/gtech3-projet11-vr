using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    [SerializeReference]
    private Collider _trappedObject;

    [SerializeField]
    private float _disappearRate = 0.7F;

    private bool _disappearing = false;


    private void Start()
    {
        if (_trappedObject)
        {
            _trappedObject.enabled = false;
        }
    }

    private void Update()
    {
        if (_disappearing)
        {
            if (transform.localScale.x > 0)
            {
                float rate = Time.deltaTime * _disappearRate;
                transform.localScale -= new Vector3(rate, rate, rate);
            }
            else
            {
                _trappedObject.enabled = true;
                gameObject.SetActive(false);
            }
        }
    }


    public void DeactivateForceField()
    {
        _disappearing = true;
    }
}
