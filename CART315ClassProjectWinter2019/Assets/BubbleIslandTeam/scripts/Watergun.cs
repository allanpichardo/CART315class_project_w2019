using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Watergun : MonoBehaviour
{
    public List<UnityEvent> onWaterCollided;
    private AudioSource audioSource;
    private ParticleLauncher particleLauncher;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        onWaterCollided = new List<UnityEvent>();
        particleLauncher = GetComponentInChildren<ParticleLauncher>();
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void Collision(GameObject gameObject)
    {
        foreach (UnityEvent unityEvent in onWaterCollided)
        {
            unityEvent.Invoke();
        }
    }

    IEnumerator TemporaryShoot()
    {
        particleLauncher.SetShooting(true);
        audioSource.Play();
        yield return new WaitForSeconds(1.0f);
        particleLauncher.SetShooting(false);
    }

    public void Shoot(bool shoot)
    {
        particleLauncher.SetShooting(shoot);
        if (shoot)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

}
