using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private bool hasHit;
    private WeaponStats stats;
    public Collider parentColl;
    private void Start()
    {
        stats = GetComponent<WeaponStats>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit || collision.gameObject.tag != "HitBox" || collision.gameObject.GetComponent<Collider>() == parentColl) Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        //collision.gameObject.GetComponent<EntityStats>().health = -stats.damage;
        Debug.Log("hit");
        hasHit = true;
    }

}
