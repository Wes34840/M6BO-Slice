using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private EntityStats playerStats;
    private Rigidbody rb;
    void Start()
    {
        playerStats = GetComponent<EntityStats>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    // ctx = the value that is given when the action is called, you can see the type of the variable in the Player Input Actions, the Action you are calling and looking at the "Control Type"
    {
        Vector3 horizontalInput = ctx.ReadValue<Vector3>();
        rb.velocity = horizontalInput * playerStats.movementSpeed;
    }
}
