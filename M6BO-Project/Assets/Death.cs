using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public EntityStats stats;
    public ComboScript combo;
    void Start()
    {
        stats= GetComponent<EntityStats>();
        combo= GetComponent<ComboScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.health <= 0)
        {
            combo.animator.SetBool("IsDead", true);
            combo.GetComponent<ComboScript>().enabled = false;
        }
    }
}
