
using UnityEngine;

public class RotatePlayerToView : MonoBehaviour
{
    private Transform _cam;
    private PlayerMovement _movement;

    private void Start()
    {
        _cam = Camera.main.transform;
        _movement = GetComponent<PlayerMovement>();
    }

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
