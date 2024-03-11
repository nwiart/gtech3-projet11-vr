using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Candle : MonoBehaviour
{
    [SerializeField] private Light _lightSource;

    [SerializeField] private string _fireTag;


    public UnityEvent OnCandleLight;


    // Start is called before the first frame update
    void Start()
    {
        _lightSource.enabled = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(_lightSource.enabled);
        if (_lightSource.enabled) return;

        if (other.CompareTag(_fireTag))
        {
            _lightSource.enabled = true;
        }

        OnCandleLight.Invoke();
    }
}
