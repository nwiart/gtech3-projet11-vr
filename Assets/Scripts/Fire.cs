using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si le collider est activ�
        if (other.gameObject.GetComponent<BoxCollider>() != null && other.gameObject.GetComponent<BoxCollider>().enabled)
        {
            // Activer tous les enfants de l'objet
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
