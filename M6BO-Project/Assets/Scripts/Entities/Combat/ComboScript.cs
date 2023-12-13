using UnityEngine;
using UnityEngine.InputSystem;

public class ComboScript : MonoBehaviour
{
    internal Animator animator;
    private bool shouldGoNextCombo;
    internal bool isAttacking;
    private bool heavyCombo;
    public HitDetection hitD;
    public SwitchWeapon canSwap;
    private bool specialAttacking;


    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void LightAttack(InputAction.CallbackContext ctx)
    {
        animator.SetBool("ShouldGoNextCombo", true);
    }

    public void HeavyAttack(InputAction.CallbackContext ctx)
    {
        animator.SetBool("HeavyCombo", true);
    }

    public void SpecialAttack(InputAction.CallbackContext ctx)
    {
        if (canSwap.currentWeapon == canSwap.halberd) animator.SetBool("AshOfWar", true);
    }
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack3") && shouldGoNextCombo == true || animator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack3") && heavyCombo == true)
        {
            ResetAttackStates();
        }
    }

    public void AnimationStarted()
    {
        if (heavyCombo) SetDamage(20);
        if (specialAttacking) SetDamage(40);
        else SetDamage(10);
        isAttacking = true;
        shouldGoNextCombo = false;
        heavyCombo = false;
        specialAttacking = false;
        canSwap.canSwitch = false;
    }
    public void AttackingEnds()
    {
        isAttacking = false;
        hitD.hits.Clear();
        canSwap.canSwitch = true;
    }

    public void SetDamage(int damage)
    {
        hitD.gameObject.GetComponent<WeaponStats>().damage = damage;
    }


    public void ResetAttackStates()
    {
        animator.SetBool("ShouldGoNextCombo", false);
        animator.SetBool("HeavyCombo", false);
        animator.SetBool("AshOfWar", false);
    }


}


