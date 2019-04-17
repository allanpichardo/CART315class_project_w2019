﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int lives;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    // Start is called before the first frame update
    void Start()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        lives = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lives <= 2)
        {
            heart3.SetActive(false);
        }
        if (lives <= 1)
        {
            heart2.SetActive(false);
        }
        if (lives <= 0)
        {
            heart1.SetActive(false);
            print("die");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision);
        if (collision.gameObject.tag == "enemy")
        {
            lives--;
        }
    }
}