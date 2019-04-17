using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int life = 5;
    public float lookDistance = 10.0f;
    public bool patrol = false;
    public UnityEvent onEnemyDeath;

    private NavMeshAgent agent;
    private Material material;
    private Color defaultColor;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>() != null ? GetComponent<Renderer>() : GetComponentInChildren<Renderer>();
        material = renderer.material;
        defaultColor = material.color;
        player = GameObject.FindGameObjectWithTag("ActivePlayer");
        agent = GetComponentInChildren<NavMeshAgent>() ? GetComponentInChildren<NavMeshAgent>() : GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive())
        {
            if (onEnemyDeath != null)
            {
                onEnemyDeath.Invoke();
            }
            Destroy(gameObject);
        }
        
        if (player && IsAlive())
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

    private bool IsAlive()
    {
        return life > 0;
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

    IEnumerator Flash()
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        material.color = defaultColor;
    }

    private void OnParticleCollision(GameObject other)
    {
        life--;
        StartCoroutine(Flash());
    }
}
