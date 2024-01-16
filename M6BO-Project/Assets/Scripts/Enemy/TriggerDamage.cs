using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerDamage : MonoBehaviour
{
    public List<Collider> hits = new List<Collider>();
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
        StartCoroutine(ClearList());
        int index = Random.Range(0, _hitSounds.Length);
        shootClip = _hitSounds[index];
        _audioSource.clip = shootClip;
        _audioSource.Play();
    }

    private IEnumerator ClearList()
    {
        yield return new WaitForSeconds(1);
        hits.Clear();
    }

}
