using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private EntityStats playerStats;
    private Rigidbody rb;
    private Vector3 dir;
    private Animator anim;
    public AudioClip walkingClip;
    private AudioSource Audio;
    public bool canMove = true;

    void Start()
    {
        playerStats = GetComponent<EntityStats>();
        rb = GetComponent<Rigidbody>();
        Audio= GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    public void OnMove(InputAction.CallbackContext ctx)
    // ctx = the value that is given when the action is called, you can see the type of the variable in the Player Input Actions, the Action you are calling and looking at the "Control Type"
    {
        Vector3 movementInput = ctx.ReadValue<Vector3>();
        dir = new Vector3(movementInput.x, 0, movementInput.z);
        SetAnimInput(movementInput);
        WalkingNoise(movementInput);
    }

    public void SetAnimInput(Vector3 input)
    {
        anim.SetInteger("HorizontalInput", (int)input.x);
        anim.SetInteger("VerticalInput", (int)input.z);
        anim.SetFloat("HorizontalMod", input.x);
        anim.SetFloat("VerticalMod", input.z);
        
        
    }

    public void WalkingNoise(Vector3 input )
    {
        Audio.PlayOneShot(walkingClip);
        if(input == Vector3.zero)
        {
            Audio.Stop();
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
        rb.velocity = ((transform.forward * dir.z) + (transform.right * dir.x)) * playerStats.movementSpeed;
       
        

    }
    private float GetGravity()
    {
        return rb.velocity.y;
    }
    private void ApplyGravity(float grav)
    {
        rb.velocity = new Vector3(rb.velocity.x, grav, rb.velocity.z);
    }
}
