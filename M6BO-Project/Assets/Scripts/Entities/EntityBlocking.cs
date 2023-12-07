using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class EntityBlocking : MonoBehaviour
{
    public EntityHitbox hitboxScript;
    public Animator anim;
    public bool canBlock;
    private void Start()
    {
        anim = GetComponent<Animator>();
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
        anim.SetBool("isBlocking", set);
        StartCoroutine(animationDelay(set));
    }
    public IEnumerator animationDelay(bool set)
    {
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips.First(i => i.name == "Blocking").length / 10);
        hitboxScript.isBlocking = set;
    }
}
