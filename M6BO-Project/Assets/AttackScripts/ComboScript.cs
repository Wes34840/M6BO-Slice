using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    internal Animator animator;
    private bool shouldGoNextCombo = false;
    internal bool isAttacking;
    private bool HeavyCombo = false;
    public HitDetection hitD;
    public SwitchWeapon canSwap;
   

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            shouldGoNextCombo = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HeavyCombo = true;

        }
        ShouldGoNextCombo(shouldGoNextCombo);
        HeavyCombos(HeavyCombo);
        

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack3") && shouldGoNextCombo == true || animator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack3") && HeavyCombo == true)
        {
            shouldGoNextCombo= false;
            HeavyCombo= false;
        }   
    }
 

    private void HeavyCombos(bool value)
    {
        animator.SetBool("HeavyCombo", value);
    }

    private void ShouldGoNextCombo(bool value)
    {
        animator.SetBool("ShouldGoNextCombo", value);
    }

    public void AnimationStarted()
    {
        if (HeavyCombo) SetDamage(20);
        else SetDamage(10);
        isAttacking = true;
        shouldGoNextCombo = false;
        HeavyCombo = false;
        canSwap.CanSwitch = false;

    }
    public void AttackingEnds()
    {
        isAttacking= false;
        hitD.hits.Clear();
        canSwap.CanSwitch = true;

    }

    public void SetDamage(int damage)
    {
        hitD.gameObject.GetComponent<WeaponStats>().damage = damage;
    }

    

    
}

    
    