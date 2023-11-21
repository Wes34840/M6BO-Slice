using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    private Animator animator;
    private float cooldown;
    private float lastClicked;
    int currentInt;

    private string[] animations = new string[] { "LightAttack1", "LightAttack2", "LightAttack3" };
    private bool shouldGoNextCombo = false;

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
    }

    public void AnimationStarted()
    {
        shouldGoNextCombo = false;
    }

    private void ShouldGoNextCombo(bool value)
    {
        animator.SetBool("ShouldGoNextCombo", value);
    }
}

    
    