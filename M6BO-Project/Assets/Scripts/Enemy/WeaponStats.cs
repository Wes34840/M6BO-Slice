using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public float damage;
    public float poiseDamage;
    public enum AttackState { Light = 1, Heavy = 2, Special = 4 };
    public AttackState currentState;

    public WeaponStats(float damage, float poiseDamage, AttackState currentState)
    {
        this.damage = damage;
        this.poiseDamage = poiseDamage;
        this.currentState = currentState;
    }
}
