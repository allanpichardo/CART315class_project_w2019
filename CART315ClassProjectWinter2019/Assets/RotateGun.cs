using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    private float rotateXAxis = 0.0f;
    private float rotateYAxis = -90.0f;

    // Start is called before the first frame update
    void Start()
    {
        rotateYAxis = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rotateYAxis -= 3 * Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(rotateYAxis, 0, -90);
    }
}
