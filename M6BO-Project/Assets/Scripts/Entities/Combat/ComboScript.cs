﻿using UnityEngine;
using UnityEngine.InputSystem;

public class ComboScript : MonoBehaviour
{
    internal Animator animator;
    internal bool isAttacking;
    public HitDetection hitD;
    public SwitchWeapon canSwap;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LightAttack(InputAction.CallbackContext ctx)
    {
        if (isAttacking) return;
        isAttacking = true;
        animator.SetBool("ShouldGoNextCombo", true);
    }

    public void HeavyAttack(InputAction.CallbackContext ctx)
    {
        if (isAttacking) return;
        isAttacking = true;
        animator.SetBool("HeavyCombo", true);
    }

    public void SpecialAttack(InputAction.CallbackContext ctx)
    {
        if (isAttacking) return;
        if (canSwap.currentWeapon == canSwap.halberd) animator.SetBool("AshOfWar", true);
    }
    /*
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack3") && animator.GetBool("ShouldGoNextCombo") || animator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack3") && animator.GetBool("HeavyCombo")) ResetAttackStates();
    }
    */

    public void AnimationStarted()
    {
        if (animator.GetBool("HeavyCombo")) SetAttackState(WeaponStats.AttackState.Heavy);
        else if (animator.GetBool("AshOfWar")) SetAttackState(WeaponStats.AttackState.Special);
        else SetAttackState(WeaponStats.AttackState.Light);
        isAttacking = true;
        ResetAttackStates();
        canSwap.canSwitch = false;
    }
    public void AttackingEnds()
    {
        isAttacking = false;
        hitD.hits.Clear();
        canSwap.canSwitch = true;
    }

    public void SetAttackState(WeaponStats.AttackState state)
    {
        hitD.gameObject.GetComponent<WeaponStats>().currentState = state;
    }

    public void ResetAttackStates()
    {
        animator.SetBool("ShouldGoNextCombo", false);
        animator.SetBool("HeavyCombo", false);
        animator.SetBool("AshOfWar", false);
    }

}

