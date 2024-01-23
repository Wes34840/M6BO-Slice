using UnityEngine;

public class CombatLunge : MonoBehaviour
{
    public Rigidbody rb;
    public bool isLunging;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLunging) return;
    }

    public void StartLunge()
    {

    }
}
