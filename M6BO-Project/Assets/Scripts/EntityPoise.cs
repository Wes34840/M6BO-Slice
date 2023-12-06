using System.Collections;
using System.Linq;
using UnityEngine;

public class EntityPoise : MonoBehaviour
{
    public Animator anim;
    public float maxPoise;
    private float currentPoise;
    public bool initialStun;
    public float CurrentPoise
    {
        get
        {
            return currentPoise;
        }
        set
        {
            if (currentPoise == value) return;
            currentPoise = value;
            if (OnVariableChange != null)
                OnVariableChange(currentPoise);
        }
    }
    public delegate void OnVariableChangeDelegate(float newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    void Start()
    {
        OnVariableChange = PoiseChanged;
        CurrentPoise = maxPoise;
        TryGetComponent(out anim);
        if (anim == null) anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (CurrentPoise < maxPoise && !initialStun) CurrentPoise += Time.deltaTime * 0.7f;
        if (CurrentPoise > maxPoise) CurrentPoise = maxPoise;
    }

    public void PoiseChanged(float currentPoise)
    {
        if (currentPoise <= 0) StunEntity();
    }

    public void StunEntity()
    {
        anim.SetTrigger("Stun");
        AnimationClip stunClip = anim.runtimeAnimatorController.animationClips.First(i => i.name == "Stun");
        StartCoroutine(WaitForDuration(stunClip.length));
    }

    public void ResetPoise()
    {
        CurrentPoise = maxPoise;
    }

    private IEnumerator WaitForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        ResetPoise();
        anim.ResetTrigger("Stun");
    }
    public IEnumerator RegenDelay()
    {
        initialStun = true;
        yield return new WaitForSeconds(0.5f);
        initialStun = false;
    }
}
