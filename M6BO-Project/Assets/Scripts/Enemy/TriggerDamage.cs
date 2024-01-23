using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private ComboScript _comboScript;
    private List<Collider> hits = new List<Collider>();
    private WeaponStats _weaponStats;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _hitSounds;
    private AudioClip shootClip;

    void Start()
    {
        _weaponStats = GetComponent<WeaponStats>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hits.Contains(other) || other.CompareTag("TriggerBox") || other.CompareTag("Weapon")) return;

        other.GetComponent<EntityHitbox>().TakeDamage(_weaponStats);
        hits.Add(other);
        int index = Random.Range(0, _hitSounds.Length);
        shootClip = _hitSounds[index];
        _audioSource.clip = shootClip;
        _audioSource.Play();
    }

    public void ClearHits()
    {
        hits.Clear();
    }

}
