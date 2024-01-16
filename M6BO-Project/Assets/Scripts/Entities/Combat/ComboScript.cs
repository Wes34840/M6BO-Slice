using UnityEngine;

public class ComboScript : MonoBehaviour
{
    public Animator anim;
    public bool isAttacking;
    private HitDetection _hitDetection;
    [SerializeField] private SwitchWeapon _switchWeapon;
    private PlayerMovement _playerMovement;
    [SerializeField] private AudioClip[] _lightSwings;
    [SerializeField] private AudioClip[] _heavySwings;
    private AudioSource _audioSource;
    void Start()
    {
        anim = GetComponent<Animator>();
        _hitDetection = GetComponentInChildren<HitDetection>();
        _playerMovement = GetComponent<PlayerMovement>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Attack(string animatorParameter)
    {
        if (isAttacking) return;
        isAttacking = true;
        if (_switchWeapon.currentWeapon == _switchWeapon.halberd)
        {
            anim.SetBool(animatorParameter, true);
            return;
        }

        anim.SetBool(animatorParameter, true);
    }

    public void InitLock()
    {
        StartCoroutine(_playerMovement.LockMovement(anim.GetCurrentAnimatorClipInfo(1).Length));
    }

    public void AnimationStarted()
    {
        if (anim.GetBool("HeavyCombo")) SetAttackState(WeaponStats.AttackState.Heavy);
        else if (anim.GetBool("AshOfWar")) SetAttackState(WeaponStats.AttackState.Special);
        else SetAttackState(WeaponStats.AttackState.Light);
        isAttacking = true;
        ResetAttackStates();
        _switchWeapon.canSwitch = false;
    }

    public void AttackingEnds()
    {
        isAttacking = false;
        _hitDetection.hits.Clear();
        _switchWeapon.canSwitch = true;
    }

    public void SetAttackState(WeaponStats.AttackState state)
    {
        _hitDetection.gameObject.GetComponent<WeaponStats>().currentState = state;
    }

    public void ResetAttackStates()
    {
        anim.SetBool("ShouldGoNextCombo", false);
        anim.SetBool("HeavyCombo", false);
        anim.SetBool("AshOfWar", false);
    }

    public void RandomAudio(AudioClip[] clips)
    {
        _audioSource.clip = clips[Random.Range(0, clips.Length)];
        _audioSource.Play();
    }

}


