using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    private Animator animator;
    private bool shouldGoNextCombo = false;
    private bool isAttacking;
    private bool HeavyCombo = false;
   

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
        Debug.Log(isAttacking);

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
        isAttacking = true;
        shouldGoNextCombo = false;
        HeavyCombo = false;

    }
    public void AttackingEnds()
    {
        isAttacking= false;
        

    }

    

    
}

    
    