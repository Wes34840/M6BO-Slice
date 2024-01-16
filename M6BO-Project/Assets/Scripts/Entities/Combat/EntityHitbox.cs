using UnityEngine;

public class EntityHitbox : MonoBehaviour
{
    public EntityStats stats;
    public EntityPoise poise;
    public bool isBlocking;
    public bool isDodging;


    public void TakeDamage(WeaponStats weapon)
    {
        if (isDodging) return;

        PlayParticle();

        float damage = CalculateDamage(weapon);
        float poiseDamage = CalculatePoise(weapon);
        if (isBlocking)
        {
            stats.health -= damage * (stats.blockingPower / 10);
            poise.CurrentPoise -= poiseDamage * (stats.blockingPower / 10);
        }
        else
        {
            stats.health -= damage;
            poise.CurrentPoise -= poiseDamage;

        }


    }

    public void PlayParticle()
    {
        GetComponent<BloodParticles>().PlayBloodSpatter();
    }

    public float CalculateDamage(WeaponStats weapon)
    {
        return weapon.damage * (int)weapon.currentState;
    }
    // this feels extremely unncsessary 
    public float CalculatePoise(WeaponStats weapon)
    {
        return weapon.poiseDamage * (int)weapon.currentState;
    }

}
