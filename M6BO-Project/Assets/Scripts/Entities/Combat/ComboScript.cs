using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class ComboScript : MonoBehaviour
{
    public Animator anim;
    public bool isAttacking;
    [SerializeField] private TriggerDamage _weaponDamageTrigger;
    [SerializeField] private SwitchWeapon _switchWeapon;
    private PlayerMovement _playerMovement;
    [SerializeField] private AudioClip[] _lightSwings;
    [SerializeField] private AudioClip[] _heavySwings;
    private List<AudioClip[]> _audioClipArrays = new List<AudioClip[]>();
    private AudioSource _audioSource;
    private Rigidbody _rb;
    public enum AudioType { Light, Heavy };
    void Start()
    {
        anim = GetComponent<Animator>()
        _weaponDamageTrigger = _switchWeapon.currentWeapon.GetComponent<TriggerDamage>();
        _playerMovement = GetComponent<PlayerMovement>();
        _audioSource = GetComponent<AudioSource>();
        _audioClipArrays.Add(_lightSwings);
        _audioClipArrays.Add(_heavySwings);
        _rb = GetComponent<Rigidbody>();
    }

    public void Attack(string animatorParameter)
    {
        Debug.Log("Called");
        if (isAttacking) return;
        isAttacking = true;
        _switchWeapon.canSwitch = false;
        if (_switchWeapon.currentWeapon == _switchWeapon.halberd)
        {
            anim.SetBool(animatorParameter, true);
            return;
        }

        anim.SetBool(animatorParameter, true);
    }

    public void ToggleMovementLock(int i)
    {
        _rb.velocity = Vector3.zero;
        switch (i)
        {
            case 0:
                _playerMovement.canMove = true;
                break;
            case 1:
                _playerMovement.canMove = false;
                break;
        }

    }
    public void AnimationStarted()
    {
        if (anim.GetBool("HeavyCombo")) SetAttackState(WeaponStats.AttackState.Heavy);
        else if (anim.GetBool("AshOfWar")) SetAttackState(WeaponStats.AttackState.Special);
        else SetAttackState(WeaponStats.AttackState.Light);
        isAttacking = true;
        ResetAttackStates();
    }

    public void AttackingEnds()
    {
        isAttacking = false;
        _weaponDamageTrigger.ClearHits();
        _switchWeapon.canSwitch = true;
    }

    public void SetAttackState(WeaponStats.AttackState state)
    {
        _weaponDamageTrigger.gameObject.GetComponent<WeaponStats>().currentState = state;
    }

    public void ResetAttackStates()
    {
        anim.SetBool("LightCombo", false);
        anim.SetBool("HeavyCombo", false);
        anim.SetBool("AshOfWar", false);
    }

    public void PlayRandomAudio(AudioType state)
    {
        AudioClip[] clips = _audioClipArrays[(int)state];
        _audioSource.clip = clips[Random.Range(0, clips.Length)];
        _audioSource.Play();
    }

}


