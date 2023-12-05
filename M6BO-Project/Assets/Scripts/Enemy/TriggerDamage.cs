using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public List<Collider> hits = new List<Collider>();
    private WeaponStats weaponStats;
    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hits.Contains(other) || other.CompareTag("TriggerBox")) return;

        other.GetComponentInParent<EntityStats>().health -= weaponStats.damage;
        Debug.Log(other.GetComponentInParent<EntityStats>().health);
        hits.Add(other);
    }

}
