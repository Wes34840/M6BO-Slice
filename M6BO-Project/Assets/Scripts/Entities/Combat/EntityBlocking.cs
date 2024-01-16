using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class EntityBlocking : MonoBehaviour
{
    private EntityHitbox _hitboxScript;
    private Animator _anim;

    private void Start()
    {
        _hitboxScript = GetComponentInChildren<EntityHitbox>();
        _anim = GetComponent<Animator>();
    }

    public void OnBlockPress(InputAction.CallbackContext ctx)
    {
        switch (ctx.ReadValue<float>())
        {
            case 0:
                ToggleBlocking(false);
                break;
            case 1:
                ToggleBlocking(true);
                break;
        }

    }

    public void ToggleBlocking(bool set)
    {
        _anim.SetBool("isBlocking", set);
        StartCoroutine(WaitForAnimationDelay(set));
    }

    public IEnumerator WaitForAnimationDelay(bool set)
    {
        yield return new WaitForSeconds(_anim.runtimeAnimatorController.animationClips.First(i => i.name == "Blocking").length / 10);
        _hitboxScript.isBlocking = set;
    }

}
