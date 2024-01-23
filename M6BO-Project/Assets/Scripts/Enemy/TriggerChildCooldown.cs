using UnityEngine;
public class TriggerChildCooldown : MonoBehaviour
{
    [SerializeField] private TriggerDamage _damageTrigger;

    public void startCooldown()
    {
        StartCoroutine(GetComponentInChildren<EnemyMeleeAttack>().WaitForCooldown());
        _damageTrigger.ClearHits();
    }

}
