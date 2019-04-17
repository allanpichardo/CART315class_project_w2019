using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private AudioSource AS;
    private int lives;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject redImage;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        redImage.SetActive(false);
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
            SceneManager.LoadScene("BubbleIsland");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            StartCoroutine(Delay(0.1f));
            lives--;
            AS.Play();
        }
    }
    private IEnumerator Delay(float waitTime)
    {
        redImage.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        redImage.SetActive(false);
    }
}
