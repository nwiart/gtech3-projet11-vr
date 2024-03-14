using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleRoom3 : MonoBehaviour
{
    [Serializable]
    public struct CableConnector
    {
        [SerializeField] public XRSocketInteractor Socket;

        [SerializeField] public int SectionFrom;
        [SerializeField] public int SectionTo;


        public GameObject Cable;
    }

    [SerializeField] private GameObject[] _cableSections;

    [SerializeField] private CableConnector[] _sockets;


    [SerializeField] private Material _litCableMaterial;


    public UnityEvent OnSolve;
    

    // Start is called before the first frame update
    void Start()
    {
        _sockets[0].Cable = null;
        _sockets[0].Socket.selectEntered.AddListener((args) => { OnAttach(0, args); });
        _sockets[0].Socket.selectExited.AddListener((args) => { OnDetach(0, args); });

        _sockets[1].Cable = null;
        _sockets[1].Socket.selectEntered.AddListener((args) => { OnAttach(1, args); });
        _sockets[1].Socket.selectExited.AddListener((args) => { OnDetach(1, args); });

        _sockets[2].Cable = null;
        _sockets[2].Socket.selectEntered.AddListener((args) => { OnAttach(2, args); });
        _sockets[2].Socket.selectExited.AddListener((args) => { OnDetach(2, args); });

        _sockets[3].Cable = null;
        _sockets[3].Socket.selectEntered.AddListener((args) => { OnAttach(3, args); });
        _sockets[3].Socket.selectExited.AddListener((args) => { OnDetach(3, args); });

        _sockets[4].Cable = null;
        _sockets[4].Socket.selectEntered.AddListener((args) => { OnAttach(4, args); });
        _sockets[4].Socket.selectExited.AddListener((args) => { OnDetach(4, args); });

        CheckCurrent();
    }
    

    private int FindConnector(int from, int to)
    {
        for (int i = 0; i < _sockets.Length; i++)
        {
            if (_sockets[i].SectionFrom == from && _sockets[i].SectionTo == to) return i;
        }
        return -1;
    }


    private void LightCable(List<MeshRenderer> cables, GameObject cable)
    {
        MeshRenderer r = cable.GetComponent<MeshRenderer>();
        if (r != null)
        {
            cables.Add(r);
        }
    }

    private void LightCables(List<MeshRenderer> cables, GameObject section)
    {
        List<GameObject> l = new List<GameObject>();
        section.GetChildGameObjects(l);

        foreach (GameObject c in l)
        {
            MeshRenderer r = c.GetComponent<MeshRenderer>();
            if (r != null)
            {
                cables.Add(r);
            }
        }
    }

    private void CheckCurrent()
    {
        List<MeshRenderer> cablesToLight = new List<MeshRenderer>();

        int con;

        LightCables(cablesToLight, _cableSections[0]);

        con = FindConnector(0, 1);
        if (con != -1 && _sockets[con].Cable != null)
        {
            LightCable(cablesToLight, _sockets[con].Cable);
            LightCables(cablesToLight, _cableSections[1]);
        }
        else goto light;

        con = FindConnector(1, 2);
        if (con != -1 && _sockets[con].Cable != null)
        {
            LightCable(cablesToLight, _sockets[con].Cable);
            LightCables(cablesToLight, _cableSections[2]);
        }
        else goto light;

        con = FindConnector(1, 3);
        if (con != -1 && _sockets[con].Cable != null)
        {
            LightCable(cablesToLight, _sockets[con].Cable);
            LightCables(cablesToLight, _cableSections[3]);
        }
        else goto light;

        con = FindConnector(3, 4);
        if (con != -1 && _sockets[con].Cable != null)
        {
            LightCable(cablesToLight, _sockets[con].Cable);
            LightCables(cablesToLight, _cableSections[4]);

            OnSolve.Invoke();
        }
        else goto light;

    light:
        foreach (MeshRenderer r in cablesToLight)
        {
            r.material = _litCableMaterial;
        }
    }

    private void OnAttach(int i, SelectEnterEventArgs args)
    {
        Debug.Log(i);
        _sockets[i].Cable = args.interactable.gameObject;

        CheckCurrent();
    }

    private void OnDetach(int i, SelectExitEventArgs args)
    {
        Debug.Log(i);
        _sockets[i].Cable = null;
    }
}
