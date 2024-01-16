using System.Collections;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public bool cooldown;
    public Animator anim;
    public Rigidbody rb;
    public EnemyFOV enemyFOV;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform == transform.parent) return;

        if (other.CompareTag("HitBox") && !cooldown && enemyFOV.FindVisibleTargets() == null)
        {
            anim.SetTrigger("Attack");
            cooldown = true;
            StartCoroutine(WaitForCooldown());
        }
    }

    public void ResetAttack()
    {
        anim.ResetTrigger("Attack");
    }

    public IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(2);
        cooldown = false;
    }
}
