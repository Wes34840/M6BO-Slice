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
        other.GetComponentInParent<EntityPoise>().CurrentPoise -= weaponStats.poiseDamage;
        StartCoroutine(other.GetComponentInParent<EntityPoise>().RegenDelay());
        hits.Add(other);
        StartCoroutine(ClearList());
    }

    private IEnumerator ClearList()
    {
        yield return new WaitForSeconds(1);
        hits.Clear();
    }
}
