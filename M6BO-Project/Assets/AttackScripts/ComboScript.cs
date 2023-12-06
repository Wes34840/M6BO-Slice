using Unity.Burst.Intrinsics;
using UnityEngine;

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

    private void Update()
    {
        switch (Input.inputString.ToLower())
        {
            case "e":
                shouldGoNextCombo = true;
                break;
            case "q":
                heavyCombo = true;
                break;
            case "u":
                if (canSwap.currentWeapon == canSwap.halberd) specialAttacking = true; ;
                break;

        }
        ShouldGoNextCombo(shouldGoNextCombo);
        HeavyCombos(heavyCombo);
        AshOfWar(specialAttacking);


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack3") && shouldGoNextCombo == true || animator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack3") && heavyCombo == true)
        {
            shouldGoNextCombo = false;
            heavyCombo = false;
        }
    }

    private void AshOfWar(bool value)
    {
        animator.SetBool("AshOfWar", value);
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
        if (heavyCombo) SetDamage(20);
        if(specialAttacking) SetDamage(40);
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




}


