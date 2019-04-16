using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float lookDistance = 10.0f;
    public bool patrol = false;

    private NavMeshAgent agent;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("ActivePlayer");
        agent = GetComponentInChildren<NavMeshAgent>() ? GetComponentInChildren<NavMeshAgent>() : GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= lookDistance)
            {
                if (!agent.isStopped)
                {
                    agent.ResetPath();
                }
                agent.SetDestination(player.transform.position);
            }
            else if(patrol && HasReachedDestination())
            {
                float x = Random.Range(-lookDistance, lookDistance);
                float y = 0.0f;
                float z = Random.Range(-lookDistance, lookDistance);
                agent.SetDestination(transform.position + new Vector3(x, y, z));
            }
        }
    }

    private bool HasReachedDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || Math.Abs(agent.velocity.sqrMagnitude) < 0.001f)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
