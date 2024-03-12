using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    private Light _light;
    private float _initialIntensity;


    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        _initialIntensity = _light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        _light.intensity = Random.Range(_initialIntensity * 0.7F, _initialIntensity * 1.2F);
    }
}
