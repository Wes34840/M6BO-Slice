using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private EntityStats playerStats;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<EntityStats>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector3 horizontalInput = ctx.ReadValue<Vector3>();
        rb.velocity = horizontalInput * playerStats.movementSpeed;
    }
}
