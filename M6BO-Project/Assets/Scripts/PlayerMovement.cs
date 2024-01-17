using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private EntityStats _playerStats;
    private Rigidbody _rb;
    private Animator _anim;
    public AudioClip walkingClip;
    private AudioSource _audioSource;
    public Vector3 inputDirection;
    public bool canMove = true;

    void Start()
    {
        _playerStats = GetComponent<EntityStats>();
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Transfers the input of the player to a vector, which is used in the update method to move the player.
    /// Sets the input value in the animator so the walking animation starts/changes
    /// </summary>
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector3 movementInput = ctx.ReadValue<Vector3>();
        inputDirection = new Vector3(movementInput.x, 0, movementInput.z);
        SetAnimInput(movementInput);
        DetermineWalkingSound(movementInput);
    }

    public void SetAnimInput(Vector3 input)
    {
        _anim.SetInteger("HorizontalInput", (int)input.x);
        _anim.SetInteger("VerticalInput", (int)input.z);
        _anim.SetFloat("HorizontalMod", input.x);
        _anim.SetFloat("VerticalMod", input.z);
    }

    public void DetermineWalkingSound(Vector3 input)
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = walkingClip;
            _audioSource.Play();
        }
        if (input == Vector3.zero)
        {
            _audioSource.Stop();
        }

    }

    public IEnumerator LockMovement(float duration)
    {
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;
    }

    private void Update()
    {
        float currGrav = GetGravity();
        if (canMove) ApplyControlMotion();
        ApplyGravity(currGrav);
    }

    private void ApplyControlMotion()
    {
        _rb.velocity = ((transform.forward * inputDirection.z) + (transform.right * inputDirection.x)) * _playerStats.movementSpeed;
    }

    private float GetGravity()
    {
        return _rb.velocity.y;
    }

    private void ApplyGravity(float grav)
    {
        _rb.velocity = new Vector3(_rb.velocity.x, grav, _rb.velocity.z);
    }
}
