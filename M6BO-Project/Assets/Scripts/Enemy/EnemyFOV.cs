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
        Collider[] targets = Physics.OverlapSphere(transform.position, _obstacleMask, _targetMask); // looks for player in a sphere around it
        if (targets.Length == 0) return null;
        Transform target = targets[0].transform;
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2) // checks if player is in view angle
        {
            Debug.Log("player in angle");
            float distanceToTarget = Vector3.Distance(transform.position, target.position); // finds distance of player
            if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask)) // checks if there is an obstacle between the player and enemy
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
