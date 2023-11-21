using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    EntityStats stats;
    [SerializeField] GameObject[] nodes;
    int index = 1;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EntityStats>();
        agent.speed = stats.movementSpeed;
        agent.SetDestination(nodes[0].transform.position);
    }

    public void StopAgent()
    {
        agent.isStopped = true;
    }

    public void StartAgent()
    {
        agent.isStopped = false;
    }
}
