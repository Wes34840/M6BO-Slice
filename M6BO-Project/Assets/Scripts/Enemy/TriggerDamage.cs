using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private ComboScript _comboScript;
    private List<Collider> hits = new List<Collider>();
    private WeaponStats _weaponStats;
    void Start()
    {
        _weaponStats = GetComponent<WeaponStats>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //insert vomiting sound effect
        if (_comboScript != null)
        {
            if (!_comboScript.isAttacking)
            {
                return;
            }
        }
        if (hits.Contains(other) || !other.CompareTag("HitBox") || other.CompareTag("Weapon")) return;

        other.GetComponent<EntityHitbox>().TakeDamage(_weaponStats);
        hits.Add(other);
    }

    public void ClearHits()
    {
        hits.Clear();
    }

}
