using UnityEngine;

public class TriggerChildCooldown : MonoBehaviour
{
    public TriggerDamage dam;
    public void startCooldown()
    {
        StartCoroutine(GetComponentInChildren<EnemyMeleeAttack>().WaitForCooldown());
        dam.hits.Clear();
    }

}
