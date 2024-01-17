
using UnityEngine;

public class RotatePlayerToView : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private PlayerMovement _movement;
    // Update is called once per frame
    void Update()
    {
        if (_movement.canMove) transform.rotation = UpdateDirection(_cam.position);
    }
    public Quaternion UpdateDirection(Vector3 target)
    {
        Vector3 lookDir = (transform.position - target).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(lookDir.x, 0, lookDir.z));
        return Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 3);
    }
}
