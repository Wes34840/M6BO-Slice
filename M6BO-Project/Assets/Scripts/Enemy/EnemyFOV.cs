using System;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask ObstacleMask;
    public Transform FindVisibleTargets()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, viewRadius, targetMask); // looks for player in a sphere around it
        if (targets.Length == 0) return null;
        Transform target = targets[0].transform;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) // checks if player is in view angle
        {
            Debug.Log("player in angle");
            float distToTarget = Vector3.Distance(transform.position, target.position); // finds distance of player
            if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, ObstacleMask)) // checks if there is an obstacle between the player and enemy
            {
                Debug.Log("player in distance");
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
