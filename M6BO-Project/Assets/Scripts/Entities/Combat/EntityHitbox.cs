﻿using UnityEngine;

public class EntityHitbox : MonoBehaviour
{
    public EntityStats stats;
    public EntityPoise poise;
    public bool isBlocking;
    public bool isDodging;

    public void TakeDamage(WeaponStats weapon)
    {
        PlayAudio();
        /*
        transform.parent.TryGetComponent(out PathingAI path);
        if (path != null) path.TryWakeUp();
        if (isDodging) return;
        float damage = CalculateDamage(weapon);
        float poiseDamage = CalculatePoise(weapon);
        Debug.Log("Triggered Damage");
        if (isBlocking)
        {
            stats.health -= damage * (stats.blockingPower / 10);
            poise.CurrentPoise -= poiseDamage * (stats.blockingPower / 10);
        }
        else
        {
            stats.health -= damage;
            poise.CurrentPoise -= poiseDamage;
            Debug.Log(damage);
            Debug.Log(poiseDamage);
        }
        */
    }

    public void PlayAudio()
    {
        
    }
    public float CalculateDamage(WeaponStats weapon)
    {
        Debug.Log(weapon.damage);
        Debug.Log(weapon.currentState);
        return weapon.damage * (int)weapon.currentState;
        
    }
    // this feels extremely unncsessary 
    public float CalculatePoise(WeaponStats weapon)
    {
        return weapon.poiseDamage * (int)weapon.currentState;
    }

}
