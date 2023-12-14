using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DodgingScript : MonoBehaviour
{
    // Start is called before the first frame update


    public Animator animator;
    BoxCollider HitBox;

    public void Start()
    {
        HitBox = transform.GetChild(2).GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
    }


    public void DodgeChildSupport(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0) return;
        Debug.Log("called");
        animator.SetBool("isDodging", true);
        float animDuration = animator.runtimeAnimatorController.animationClips.First(i => i.name == "Dodge").length;
        StartCoroutine(WaitForAnimLength(animDuration));
        // Trigger I-Frames here

    }
    public IEnumerator WaitForAnimLength(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsDodging", false);
    }


}
