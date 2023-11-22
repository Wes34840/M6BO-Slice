using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    private Animator animator;
    private bool shouldGoNextCombo = false;
    private bool isAttacking;

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

        ShouldGoNextCombo(shouldGoNextCombo);
        
        Debug.Log(isAttacking);
    }

    public void AnimationStarted()
    {
        isAttacking= true;
        shouldGoNextCombo = false;
    }

    private void ShouldGoNextCombo(bool value)
    {
        animator.SetBool("ShouldGoNextCombo", value);
        

    }

    private void AttackingEnds()
    {
        isAttacking= false;
    }
}

    
    