using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    public Vector3 impulse = new Vector3 (0.0f, 0.0f, 0.0f);

    bool m_oneTime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!m_oneTime)
        {
            GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
            m_oneTime = true;
        }
    }
}
