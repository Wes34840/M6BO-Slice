using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public float damage;
    public float poiseDamage;
    public enum AttackState { Light = 1, Heavy = 2, Special = 4 };
    public AttackState currentState;
}
