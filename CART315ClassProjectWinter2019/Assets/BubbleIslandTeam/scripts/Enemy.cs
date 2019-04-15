using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float lookDistance = 10.0f;

    private NavMeshAgent agent;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ActivePlayer");
        agent = GetComponentInChildren<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            Debug.Log(distance);
            if (distance <= lookDistance)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }
}
