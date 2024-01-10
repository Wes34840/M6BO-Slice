
using UnityEngine;

public class RotatePlayerToView : MonoBehaviour
{
    public Transform cam;
    public PlayerMovement movement;

    // Update is called once per frame
    void Update()
    {
        if (movement.canMove) transform.rotation = UpdateDirection(cam.position);
    }
    private Quaternion UpdateDirection(Vector3 target)
    {
        Vector3 lookDir = (transform.position - target).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(lookDir.x, 0, lookDir.z));
        return Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 3);
    }
}
