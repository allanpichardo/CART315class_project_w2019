using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public AudioClip explosion;
    public GameObject bubble;
    private AudioSource AS;
    private GameObject[] gameObjects;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    public void OnDeath()
    {
        AS.Play();
        gameObjects = GameObject.FindGameObjectsWithTag("enemy");

        for (int i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);

        StartCoroutine(Delay(1f));
    }
    private IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        AS.PlayOneShot(explosion);
        Destroy(bubble);
        //yield return new WaitForSeconds(waitTime);
    }
}
