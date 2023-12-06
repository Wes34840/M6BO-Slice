using Unity.Burst.Intrinsics;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    internal Animator animator;
    private bool shouldGoNextCombo = false;
    internal bool isAttacking;
    private bool HeavyCombo = false;
    public HitDetection hitD;
    public SwitchWeapon canSwap;
    private bool SpecialAttacking = false;


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
                HeavyCombo = true;
                break;
            case "u":
                if (canSwap.currentWeapon == canSwap.halberd) SpecialAttacking = true; ;
                break;

        }
        ShouldGoNextCombo(shouldGoNextCombo);
        HeavyCombos(HeavyCombo);
        AshOfWar(SpecialAttacking);


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack3") && shouldGoNextCombo == true || animator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack3") && HeavyCombo == true)
        {
            shouldGoNextCombo = false;
            HeavyCombo = false;
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
        if (HeavyCombo) SetDamage(20);
        if(SpecialAttacking) SetDamage(40);
        else SetDamage(10);
        isAttacking = true;
        shouldGoNextCombo = false;
        HeavyCombo = false;
        SpecialAttacking = false;
        canSwap.CanSwitch = false;

    }
    public void AttackingEnds()
    {
        isAttacking = false;
        hitD.hits.Clear();
        canSwap.CanSwitch = true;

    }

    public void SetDamage(int damage)
    {
        hitD.gameObject.GetComponent<WeaponStats>().damage = damage;
    }




}


