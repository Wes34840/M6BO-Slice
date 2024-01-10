using UnityEngine;

public class BasicEnemyLunge : MonoBehaviour
{
    private EntityStats stats;
    public bool isLunging;
    private Rigidbody rb;
    private Vector3 lungeDir;
    void Start()
    {
        stats = GetComponent<EntityStats>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag = 40;
        if (isLunging)
        {
            rb.drag = 0;
            rb.velocity = lungeDir * stats.movementSpeed;
        }
    }

    public void GetLungeDirection(Vector3 dir)
    {
        lungeDir = dir;
    }

}
