using System.Collections;
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
        if (hits.Contains(other) || other.CompareTag("TriggerBox") || other.CompareTag("Weapon")) return;
        other.GetComponent<EntityHitbox>().TakeDamage(weaponStats);
        hits.Add(other);
        StartCoroutine(ClearList());
    }

    private IEnumerator ClearList()
    {
        yield return new WaitForSeconds(1);
        hits.Clear();
    }
}
