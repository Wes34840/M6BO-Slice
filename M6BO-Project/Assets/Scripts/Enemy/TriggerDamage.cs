using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerDamage : MonoBehaviour
{
    public List<Collider> hits = new List<Collider>();
    private WeaponStats weaponStats;
    private AudioSource source; 
    public AudioClip[] hitSounds;
    private AudioClip shootClip;
    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
        source= GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (hits.Contains(other) || other.CompareTag("TriggerBox") || other.CompareTag("Weapon")) return;
      
        other.GetComponent<EntityHitbox>().TakeDamage(weaponStats);
        hits.Add(other);
        StartCoroutine(ClearList());
        int index = Random.Range(0, hitSounds.Length);
        shootClip = hitSounds[index];
        source.clip= shootClip; 
        source.Play(); 



    }

    private IEnumerator ClearList()
    {
        yield return new WaitForSeconds(1);
        hits.Clear();
    }
}
