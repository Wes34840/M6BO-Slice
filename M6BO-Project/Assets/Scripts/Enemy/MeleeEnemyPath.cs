using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyPath : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    EntityStats stats;
    [SerializeField] GameObject[] nodes;

    public Transform model;

    public bool awoken;
    private EnemyFOV fov;
    private float aggroTimer;
    void Start()
    {
        model = transform.GetChild(0);
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EntityStats>();
        fov = GetComponent<EnemyFOV>();
        agent.isStopped = true;
        agent.speed = stats.movementSpeed;
    }

    private void Update()
    {
        aggroTimer -= Time.deltaTime;
        Vector3 targetPos = fov.FindVisibleTargets();
        if (targetPos != new Vector3() && agent.enabled)
        {
            if (!awoken)
            {
                agent.isStopped = false;
                awoken = true;
            }
            agent.SetDestination(targetPos);
            fov.viewAngle = 360;
            aggroTimer = 20;
        }

        if (agent.enabled)
        {
            GetComponent<Rigidbody>().freezeRotation = false;
            model.rotation = UpdateDirection(agent.steeringTarget);
        }
        else GetComponent<Rigidbody>().freezeRotation = true;

        if (aggroTimer <= 0)
        {
            fov.viewAngle = 190;
        }
    }

    private Quaternion UpdateDirection(Vector3 target)
    {
        Vector3 lookDir = (target - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(lookDir.x, 0, lookDir.z));
        return Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5);
    }

}
