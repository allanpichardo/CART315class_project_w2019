﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    public int maxSpawnNumber = 10;
    private int numberOfDucks = 0;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        StartCoroutine(SpawnDelay(spawnTime));
    }

    private void FixedUpdate()
    {

    }

    private IEnumerator SpawnDelay(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (numberOfDucks < maxSpawnNumber)
            {
                Spawn();
            }
        }
    }

    public void OnDeath()
    {
        numberOfDucks--;
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject duck = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        duck.GetComponent<Enemy>().onEnemyDeath.AddListener(OnDeath);
        numberOfDucks++;
    }
}
