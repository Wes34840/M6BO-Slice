using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyComboScript : MonoBehaviour
{
    private Animator animator;
    private bool HeavyCombo = false;
    private bool isHeavyAttacking;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HeavyCombo = true;
            
        }

        HeavyCombos(HeavyCombo);
    }

    public void AnimationStarts()
    {
        HeavyCombo = true;
        isHeavyAttacking= true;
    }

    private void HeavyCombos(bool value)
    {
        animator.SetBool("HeavyCombo", value);
    }

    private void HeavyAttackingEnds()
    {
        isHeavyAttacking = false;
    }
}

    
    

