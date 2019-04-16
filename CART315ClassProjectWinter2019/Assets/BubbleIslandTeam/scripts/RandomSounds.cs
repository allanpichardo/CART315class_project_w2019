using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndPrint(Random.Range(4.0f, 10.0f))); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    // every 2 seconds perform the print()
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GetComponent<AudioSource>().Play();
        }
    }
}
