using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject prefab;
    public bool onCooldown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootProjectile(Transform target)
    {
        GameObject proj = Instantiate(prefab, transform.position, Quaternion.identity);
        proj.GetComponent<CollisionDamage>().parentColl = GetComponentInChildren<Collider>();
        proj.GetComponent<Rigidbody>().velocity = GetProjectileVelocity(target);
        StartCoroutine(WaitForCooldown(5));
    }
    private Vector3 GetProjectileVelocity(Transform target)
    {
        Vector3 direction = (target.position - transform.position);
        return new Vector3(direction.x * 10, direction.y * 5, direction.z * 10);
    }

    private IEnumerator WaitForCooldown(float timer)
    {
        onCooldown = true;
        yield return new WaitForSeconds(timer);
        onCooldown = false;
    }
}
