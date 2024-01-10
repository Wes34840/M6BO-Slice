
using UnityEngine;
public class CollisionDamage : MonoBehaviour
{
    private bool hasHit;
    private WeaponStats stats;
    public Collider parentColl;
    private void Start()
    {
        stats = GetComponent<WeaponStats>();
        Physics.IgnoreCollision(parentColl, GetComponent<BoxCollider>());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit || collision.gameObject.tag != "HitBox")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<BoxCollider>());
            return;
        }
        //collision.gameObject.GetComponent<EntityStats>().health = -stats.damage;

        hasHit = true;
    }

}
