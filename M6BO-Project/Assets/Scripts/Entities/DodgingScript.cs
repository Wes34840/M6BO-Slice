using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DodgingScript : MonoBehaviour
{
    private Animator animator;
    private EntityHitbox HitBox;
    private PlayerMovement movementScript;
    private Rigidbody rb;
    private bool isRolling;
    [SerializeField] private float rollForce;
    private Vector3 rollDirection;
    public void Start()
    {
        HitBox = transform.GetChild(2).GetComponent<EntityHitbox>();
        animator = GetComponent<Animator>();
        movementScript = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    public void InitDodge(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || isRolling) return;
        animator.SetBool("IsDodging", true);
        float animDuration = animator.runtimeAnimatorController.animationClips.First(i => i.name == "Dodge").length - 0.1f;
        StartCoroutine(WaitForAnimLength(animDuration));
        isRolling = true;
        movementScript.canMove = false;
        HitBox.isDodging = true;
        rb.velocity = Vector3.zero;

        rollDirection = GetRollDirection();
        if (rollDirection != transform.forward) RotatePlayer(movementScript.inputDir);
    }
    public IEnumerator WaitForAnimLength(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsDodging", false);
        isRolling = false;
        movementScript.canMove = true;
        HitBox.isDodging = false;
    }

    private Vector3 GetRollDirection()
    {
        Vector3 input = movementScript.inputDir;
        if (input == Vector3.zero) return transform.forward;
        return (transform.forward * input.z) + (transform.right * input.x).normalized;
    }

    private void RotatePlayer(Vector3 inputDir)
    {
        float lookDir = Mathf.Atan2(inputDir.x, inputDir.z);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + (Mathf.Rad2Deg * lookDir), 0);
    }

    private void Update()
    {
        if (!isRolling) return;
        transform.position += rollDirection * rollForce * Time.deltaTime;
    }


}
