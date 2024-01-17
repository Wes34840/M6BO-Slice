using UnityEngine;

public class EntityHitbox : MonoBehaviour
{
    private EntityStats _entityStats;
    private EntityPoise _poiseScript;
    public bool isBlocking;
    public bool isDodging;

    public void TakeDamage(WeaponStats weapon)
    {
        PlayAudio();

        transform.parent.TryGetComponent(out PathingAI path);
        if (path != null) path.TryWakeUp();
        if (isDodging) return;
        float damage = CalculateDamage(weapon);
        float poiseDamage = CalculatePoise(weapon);
        Debug.Log("Triggered Damage");
        if (isBlocking)
        {
            _entityStats.health -= damage * (_entityStats.blockingPower / 10);
            _poiseScript.currentPoise -= poiseDamage * (_entityStats.blockingPower / 10);
        }

        else
        {
            _entityStats.health -= damage;
            _poiseScript.currentPoise -= poiseDamage;
            Debug.Log(damage);
            Debug.Log(poiseDamage);
        }

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
    // this feels extremely unnecessary 
    public float CalculatePoise(WeaponStats weapon)
    {
        return weapon.poiseDamage * (int)weapon.currentState;
    }

}
