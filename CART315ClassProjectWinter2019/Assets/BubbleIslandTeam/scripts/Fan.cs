using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float thrust = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && other.attachedRigidbody != null)
        {
            other.attachedRigidbody.AddForce(Vector3.up * thrust, ForceMode.Impulse);
//            other.gameObject.transform.Translate(Vector3.up * thrust);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
