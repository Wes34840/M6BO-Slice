using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DodgingScript : MonoBehaviour
{
    // Start is called before the first frame update


    public Animator animator;
    EntityHitbox HitBox;
    private bool isRolling;
    private Rigidbody rb;

    public void Start()
    {
        HitBox = transform.GetChild(2).GetComponent<EntityHitbox>();
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody>();
    }


    public void DodgeChildSupport(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0) return;
        Debug.Log("called");
        animator.SetBool("IsDodging", true);
        float animDuration = animator.runtimeAnimatorController.animationClips.First(i => i.name == "Dodge").length;
        StartCoroutine(WaitForAnimLength(animDuration));
        // Trigger I-Frames here
        HitBox.isDodging = true;
        isRolling = true;

    }
    public IEnumerator WaitForAnimLength(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsDodging", false);
        HitBox.isDodging = false;
        isRolling= false;
    }
    private void Update()
    {
        if (!isRolling) return;
        rb.velocity = transform.forward * 1.5f;
    }


}
