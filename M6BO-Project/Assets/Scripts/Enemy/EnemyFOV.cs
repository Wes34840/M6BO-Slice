using System;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstacleMask;
    public Transform FindVisibleTargets()
    {
        // looks for player in a sphere around it
        Collider[] targets = Physics.OverlapSphere(transform.position, viewRadius, _targetMask);
        if (targets.Length == 0) return null;
        Transform target = targets[0].transform;
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Debug.Log("target in sphere");

        // checks if player is in view angle
        if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
        {
            Debug.Log("player in angle");

            // finds distance of player
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // checks if there is an obstacle between the player and enemy
            if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask))
            {
                return targets[0].transform;
            }
        }
        return null;

    }

    public Vector3 DirFromAngle(float angle, bool isGlobal)
    {
        if (!isGlobal)
        {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

}
