using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyComboScript : MonoBehaviour
{
    private Animator animator;
    private bool HeavyCombo = false;

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
        HeavyCombo = false;
    }

    private void HeavyCombos(bool value)
    {
        animator.SetBool("HeavyCombo", value);
    }
}

    
    

