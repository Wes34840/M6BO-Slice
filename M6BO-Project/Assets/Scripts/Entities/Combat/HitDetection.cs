using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public ComboScript combo;
    public List<Collider> hits = new List<Collider>();
    private float enemyHealth;
    private float enemyHealthMax;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (combo.isAttacking && other.CompareTag("HitBox") && !hits.Contains(other))
        {
            hits.Add(other);
            other.GetComponentInParent<EntityStats>().health -= GetComponent<WeaponStats>().damage;
        }
    }


}
