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
        if (isBlocking)
        {
            stats.health -= weapon.damage * (stats.blockingPower / 10);
            poise.CurrentPoise -= weapon.poiseDamage * (stats.blockingPower / 10);
        }
        else
        {
            stats.health -= weapon.damage;
            poise.CurrentPoise -= weapon.poiseDamage;
        }
    }

}
