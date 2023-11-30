using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAttack : MonoBehaviour
{
    public bool cooldown;
    public Animator anim;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform == transform.parent) return;

        if (other.CompareTag("HitBox") && !cooldown)
        {
            anim.SetTrigger("Attack");
            cooldown = true;
        }
    }

    public void ResetAttack()
    {
        anim.ResetTrigger("Attack");
    }

    public IEnumerator waitForCooldown()
    {
        yield return new WaitForSeconds(2);
        cooldown = false;
        Debug.Log(GetComponentInParent<NavMeshAgent>().enabled);
    }

}
