using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyPath : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    EntityStats stats;

    public Transform model;

    public bool awoken, isFleeing;
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

        if (isFleeing) return;

        Vector3 targetPos = fov.FindVisibleTargets();
        if (targetPos != new Vector3() && agent.enabled)
        {
            if (!awoken)
            {
                agent.isStopped = false;
                awoken = true;
            }
            agent.stoppingDistance = 8;
            agent.SetDestination(targetPos);
            fov.viewAngle = 360;
            aggroTimer = 20;

            //RaycastHitAll hit = 



            if (agent.remainingDistance < 5)
            {
                isFleeing = true;
                agent.SetDestination((agent.destination - transform.position).normalized * stats.movementSpeed * -3);
                StartCoroutine(FleeFromPlayer());
            }

        }

        if (targetPos == new Vector3()) agent.stoppingDistance = 0;

        model.rotation = UpdateDirection(agent.steeringTarget);

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

    private IEnumerator FleeFromPlayer()
    {
        agent.stoppingDistance = 0;
        yield return new WaitForSeconds(3);
        isFleeing = false;
    }
}
