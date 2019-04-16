using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
            Debug.Log(this.name + " " + distance);
            if (distance <= lookDistance)
            {
                agent.SetDestination(player.transform.position);
            }
            else if(patrol && agent.remainingDistance < 1.0f)
            {
                float x = Random.Range(0, lookDistance);
                float y = 0.0f;
                float z = Random.Range(0, lookDistance);
                agent.SetDestination(transform.position + new Vector3(x, y, z));
            }
        }
    }
}
