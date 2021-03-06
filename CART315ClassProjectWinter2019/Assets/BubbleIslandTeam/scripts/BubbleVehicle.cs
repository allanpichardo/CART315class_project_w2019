﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleVehicle : MonoBehaviour
{
    private Camera Cam;
    public List<GameObject> Children;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Camera_Become").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Cam == null)
        {
            Cam = GameObject.Find("Camera_Become").GetComponent<Camera>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 4)
        {
            print("pop bubble");

            foreach (Transform child in transform)
            {
                if (child.tag == "ActivePlayer")
                {
                    Children.Add(child.gameObject);
                    child.transform.parent = null;
                    child.gameObject.GetComponent<RigidBodyController>().enabled = false;
                }
            }
            if (Children.Count != 0)
            {
                GameObject.Find("Camera_Become").transform.parent = Children[0].transform;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ActivePlayer")
        {
            Cam.gameObject.transform.parent.parent = gameObject.transform;
            if(Cam.gameObject.GetComponent<Become>().GetCamMode() == 1)
            {
                Cam.gameObject.transform.localPosition = new Vector3(0.05f, 0.15f, 0.1f);
            }
            else
            {
                Cam.gameObject.transform.localPosition = new Vector3(0, 1, -1);
            }
            Cam.gameObject.transform.parent = gameObject.transform;
            other.gameObject.transform.localPosition = new Vector3(0,0,0);
            other.gameObject.GetComponent<RigidBodyController>().enabled = false;

        }

    }

//    private void OnTriggerStay(Collider other)
//    {
//        if (other.gameObject.tag == "ActivePlayer")
//        {
//            other.gameObject.transform.localPosition = new Vector3(0,0,0);
//            other.attachedRigidbody.freezeRotation = true;
//        }
//    }
    
}
