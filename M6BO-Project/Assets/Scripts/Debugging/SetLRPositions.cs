using UnityEngine;

public class SetLRPositions : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, target.position);
        lr.SetPosition(1, transform.position);
    }
}
