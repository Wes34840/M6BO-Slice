using System.Collections;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    public bool onCooldown;
    [SerializeField] private Transform _firingPoint;

    public void ShootProjectile(Transform target)
    {
        GameObject projectile = Instantiate(_prefab, _firingPoint.position, Quaternion.identity);
        projectile.GetComponent<CollisionDamage>().parentColl = GetComponentInChildren<Collider>();
        projectile.GetComponent<Rigidbody>().velocity = GetProjectileVelocity(target);
        StartCoroutine(WaitForCooldown(5));
    }

    private Vector3 GetProjectileVelocity(Transform target)
    {
        Vector3 direction = (target.position - transform.position);
        return new Vector3(direction.x * 2, (direction.y + 1f) * 1.2f, direction.z * 2);
    }

    private IEnumerator WaitForCooldown(float timeInSeconds)
    {
        onCooldown = true;
        yield return new WaitForSeconds(timeInSeconds);
        onCooldown = false;
    }

}
