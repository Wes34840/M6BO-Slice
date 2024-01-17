using System.Collections;
using UnityEngine;

public class RangeEnemyPath : PathingAI
{
    [SerializeField] private int _maxDist;
    private bool _isFleeing = false;
    private EnemyRangeAttack _attackScript;

    public override void Start()
    {
        GetAll();
        _attackScript = GetComponent<EnemyRangeAttack>();
    }

    public override void CheckForPlayer()
    {
        Transform target = enemyfov.FindVisibleTargets();
        if (target != null && agent.enabled)
        {
            Vector3 targetPos = target.position;
            if (!awoken)
            {
                agent.isStopped = false;
                awoken = true;
            }
            enemyfov.viewAngle = 360;
            aggroTimer = 20;

            if (_isFleeing) return;

            agent.stoppingDistance = _maxDist + 5;

            agent.SetDestination(targetPos);
            CheckIfShouldFlee();
            if (_isFleeing) return;
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
        if (agent.remainingDistance < _maxDist && (agent.destination - transform.position).magnitude < _maxDist)
        {
            _isFleeing = true;
            Vector3 dest = (agent.destination - transform.position);
            agent.SetDestination(-dest * 5); // run away from player in opposite direction
            StartCoroutine(FleeFromPlayer());
        }
    }

    private void CheckIfShouldShoot(Transform target)
    {
        if (!_attackScript.onCooldown) _attackScript.ShootProjectile(target);
    }

    private IEnumerator FleeFromPlayer()
    {
        agent.stoppingDistance = 0;
        yield return new WaitForSeconds(2);
        _isFleeing = false;
        agent.stoppingDistance = _maxDist + 5;
    }

}
