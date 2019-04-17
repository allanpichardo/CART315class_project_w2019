using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    private AudioSource AS;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    public void OnDeath()
    {
        AS.Play();
        StartCoroutine(Delay(2f));
    }
    private IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("break");
    }
}
