using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localPosition.z <= -75) 
        {
            transform.localPosition += new Vector3(0, 0, speed * Time.deltaTime);

        }

    }
}
