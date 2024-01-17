using System.Collections;
using System.Linq;
using UnityEngine;

public class EntityPoise : MonoBehaviour
{
    private Animator _anim;
    public float maxPoise;
    private float _currentPoise;
    private bool _initialStun;

    public float currentPoise
    {
        get
        {
            return _currentPoise;
        }
        set
        {
            if (_currentPoise == value) return;
            _currentPoise = value;
            if (OnVariableChange != null) OnVariableChange(_currentPoise);
        }
    }
    public delegate void OnVariableChangeDelegate(float newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    void Start()
    {
        OnVariableChange = PoiseChanged;
        currentPoise = maxPoise;
        TryGetComponent(out _anim);
        if (_anim == null) _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (currentPoise < maxPoise && !_initialStun) currentPoise += Time.deltaTime * 0.7f;
        if (currentPoise > maxPoise) currentPoise = maxPoise;
    }

    public void PoiseChanged(float currentPoise)
    {
        if (currentPoise <= 0) StunEntity();
    }

    public void StunEntity()
    {
        _anim.SetTrigger("Stun");
        AnimationClip stunClip = _anim.runtimeAnimatorController.animationClips.First(i => i.name == "Stun");
        StartCoroutine(WaitForDuration(stunClip.length));
        TryGetComponent(out PlayerMovement movement);
        if (movement != null) StartCoroutine(movement.LockMovement(stunClip.length));
    }

    public void ResetPoise()
    {
        currentPoise = maxPoise;
    }

    private IEnumerator WaitForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        ResetPoise();
        _anim.ResetTrigger("Stun");
    }

    public IEnumerator RegenDelay()
    {
        _initialStun = true;
        yield return new WaitForSeconds(0.5f);
        _initialStun = false;
    }

}
