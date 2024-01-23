using System.Collections;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private bool _cooldown;
    [SerializeField] private Animator _anim;
    [SerializeField] private EnemyFOV _enemyFOV;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform == transform.parent) return;

        if (other.CompareTag("HitBox") && !_cooldown)
        {
            _anim.SetTrigger("Attack");
            _cooldown = true;
            StartCoroutine(WaitForCooldown());
        }
    }

    public void ResetAttack()
    {
        _anim.ResetTrigger("Attack");
    }

    public IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(2);
        _cooldown = false;
    }
}
