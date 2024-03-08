using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private MeshRenderer _mesh;

    private bool _opening = false;
    private float _dissolveBias = 0.0F;


    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!_opening) return;

        _dissolveBias += Time.deltaTime;
        _mesh.material.SetFloat("_Bias", _dissolveBias);

        if (_dissolveBias >= 1.0F)
        {
            Destroy(gameObject);
        }
    }


    public void Open()
    {
        _opening = true;
    }
}
