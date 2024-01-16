using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject prefab;
    public bool onCooldown;
    public Transform firingPoint;
    public void ShootProjectile(Transform target)
    {
        GameObject proj = Instantiate(prefab, firingPoint.position, Quaternion.identity);
        proj.GetComponent<CollisionDamage>().parentColl = GetComponentInChildren<Collider>();
        proj.GetComponent<Rigidbody>().velocity = GetProjectileVelocity(target);
        StartCoroutine(WaitForCooldown(5));
    }
    private Vector3 GetProjectileVelocity(Transform target)
    {
        Vector3 direction = (target.position - transform.position);
        return new Vector3(direction.x * 2, (direction.y + 1f) * 1.2f, direction.z * 2);
    }

    private IEnumerator WaitForCooldown(float timer)
    {
        onCooldown = true;
        yield return new WaitForSeconds(timer);
        onCooldown = false;
    }
}
