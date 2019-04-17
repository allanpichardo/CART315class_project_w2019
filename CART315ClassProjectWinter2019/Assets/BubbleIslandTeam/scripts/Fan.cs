using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float thrust = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12 && other.attachedRigidbody != null)
        {
            Debug.Log("FanOn");
            other.attachedRigidbody.AddForce(Vector3.up * thrust, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
