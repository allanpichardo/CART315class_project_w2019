using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public float speed = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
