using UnityEngine;

public class TriggerChildCooldown : MonoBehaviour
{
    public TriggerDamage dam;
    public void startCooldown()
    {
        StartCoroutine(GetComponentInChildren<EnemyMeleeAttack>().waitForCooldown());
        dam.hits.Clear();
    }

}
