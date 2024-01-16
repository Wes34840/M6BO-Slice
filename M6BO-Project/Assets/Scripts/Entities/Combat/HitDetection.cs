using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public ComboScript comboScript;
    public List<Collider> hits = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (comboScript.isAttacking && other.CompareTag("HitBox") && !hits.Contains(other))
        {
            hits.Add(other);
            other.GetComponent<EntityHitbox>().TakeDamage(GetComponent<WeaponStats>());
        }
    }


}
