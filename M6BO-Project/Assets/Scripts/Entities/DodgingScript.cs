using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DodgingScript : MonoBehaviour
{
    private Animator _anim;
    private EntityHitbox _hitboxScript;
    private PlayerMovement _movementScript;
    private Rigidbody _rb;
    private bool _isRolling;
    [SerializeField] private float _rollForce;
    private Vector3 _rollDirection;

    public void Start()
    {
        _hitboxScript = transform.GetChild(2).GetComponent<EntityHitbox>();
        _anim = GetComponent<Animator>();
        _movementScript = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody>();
    }

    public void InitDodge(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || _isRolling) return;
        _anim.SetBool("IsDodging", true);
        float animDuration = _anim.runtimeAnimatorController.animationClips.First(i => i.name == "Dodge").length - 0.1f;
        StartCoroutine(WaitForAnimLength(animDuration));
        _isRolling = true;
        _movementScript.canMove = false;
        _hitboxScript.isDodging = true;
        _rb.velocity = Vector3.zero;

        _rollDirection = GetRollDirection();
        if (_rollDirection != transform.forward) RotatePlayer(_movementScript.inputDirection);
    }

    public IEnumerator WaitForAnimLength(float delay)
    {
        yield return new WaitForSeconds(delay);
        _anim.SetBool("IsDodging", false);
        _isRolling = false;
        _movementScript.canMove = true;
        _hitboxScript.isDodging = false;
    }

    private Vector3 GetRollDirection()
    {
        Vector3 input = _movementScript.inputDirection;
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
        if (!_isRolling) return;
        transform.position += _rollDirection * _rollForce * Time.deltaTime;
    }

}
