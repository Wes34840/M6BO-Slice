using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyPath : PathingAI
{
    public int maxDist;
    public bool isFleeing = false;
    public GameObject playNode, runNode;
    public EnemyRangeAttack attack;
    private void Start()
    {
        GetAll();
        attack = GetComponent<EnemyRangeAttack>();
    }
    public override void CheckForPlayer()
    {
        Transform target = fov.FindVisibleTargets();
        if (target != null && agent.enabled)
        {
            Vector3 targetPos = target.position;
            if (!awoken)
            {
                agent.isStopped = false;
                awoken = true;
            }
            fov.viewAngle = 360;
            aggroTimer = 20;

            if (isFleeing) return;

            agent.stoppingDistance = maxDist + 5;

            agent.SetDestination(targetPos);
            playNode.transform.position = targetPos;
            CheckIfShouldFlee();
            if (isFleeing) return;
            CheckIfShouldShoot(target);

        }
        else agent.stoppingDistance = 0;
    }
    public override void HandleRotation()
    {
        if (agent.remainingDistance < agent.stoppingDistance) model.rotation = UpdateDirection(agent.destination);
        else model.rotation = UpdateDirection(agent.steeringTarget);
    }

    private void CheckIfShouldFlee()
    {
        if (agent.remainingDistance < maxDist && (agent.destination - transform.position).magnitude < maxDist)
        {
            isFleeing = true;
            Vector3 dest = (agent.destination - transform.position);
            agent.SetDestination(-dest * 5); // run away from player in opposite direction
            runNode.transform.position = agent.destination;
            StartCoroutine(FleeFromPlayer());
        }
    }
    private void CheckIfShouldShoot(Transform target)
    {
        if (!attack.onCooldown) attack.ShootProjectile(target);
    }
    private IEnumerator FleeFromPlayer()
    {
        agent.stoppingDistance = 0;
        yield return new WaitForSeconds(2);
        isFleeing = false;
        agent.stoppingDistance = maxDist + 5;
    }

}
