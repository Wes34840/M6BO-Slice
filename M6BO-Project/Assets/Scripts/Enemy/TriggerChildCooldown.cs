using UnityEngine;
public class TriggerChildCooldown : MonoBehaviour
{
    [SerializeField] private TriggerDamage _damageTrigger;

    public void StartCooldown()
    {
        StartCoroutine(GetComponentInChildren<EnemyMeleeAttack>().WaitForCooldown());
        _damageTrigger.hits.Clear();
    }
}
