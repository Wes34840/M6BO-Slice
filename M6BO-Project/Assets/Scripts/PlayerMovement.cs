using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private EntityStats playerStats;
    private Rigidbody rb;
    private Vector3 dir;
    void Start()
    {
        playerStats = GetComponent<EntityStats>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    // ctx = the value that is given when the action is called, you can see the type of the variable in the Player Input Actions, the Action you are calling and looking at the "Control Type"
    {
        Vector3 horizontalInput = ctx.ReadValue<Vector3>();
        dir = new Vector3(horizontalInput.x, 0, horizontalInput.z);
    }
    private void Update()
    {
        float currGrav = GetGravity();
        ApplyControlMotion();
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
