using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float thrust = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && other.attachedRigidbody != null)
        {
            other.attachedRigidbody.AddForce(Vector3.up * thrust, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
