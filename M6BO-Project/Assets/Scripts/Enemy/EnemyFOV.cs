using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask ObstacleMask;
    public Vector3 FindVisibleTargets()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (targets.Length == 0) return new Vector3();
        Transform target = targets[0].transform;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
        {
            float distToTarget = Vector3.Distance(transform.position, target.position);
            if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, ObstacleMask))
            {
                return targets[0].transform.position;
            }
        }
        return new Vector3();
        
    }

    public Vector3 DirFromAngle(float angle, bool isGlobal)
    {
        if (!isGlobal)
        {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle* Mathf.Deg2Rad));
    }

}
