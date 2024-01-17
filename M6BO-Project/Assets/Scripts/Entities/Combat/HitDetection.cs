using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private ComboScript _comboScript;
    public List<Collider> hits = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (_comboScript.isAttacking && other.CompareTag("HitBox") && !hits.Contains(other))
        {
            hits.Add(other);
            other.GetComponent<EntityHitbox>().TakeDamage(GetComponent<WeaponStats>());
        }
    }


}
