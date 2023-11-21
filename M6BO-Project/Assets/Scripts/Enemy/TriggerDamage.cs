using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    private List<Collider> hits = new List<Collider>();
    private WeaponStats weaponStats;
    // Start is called before the first frame update
    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hits.Contains(other) || other.CompareTag("TriggerBox")) return;
       
        other.GetComponent<EntityStats>().health -= weaponStats.damage;
        hits.Add(other);
    }
}
