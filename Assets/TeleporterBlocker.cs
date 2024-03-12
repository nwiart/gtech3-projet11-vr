using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleporterBlocker : MonoBehaviour
{
    [SerializeField] XRRayInteractor _teleportInteract;

    private void OnTriggerEnter(Collider other)
    {
        _teleportInteract.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        _teleportInteract.enabled = true;
    }
}
