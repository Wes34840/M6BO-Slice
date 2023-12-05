using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public EntityStats stats;
    void Start()
    {
        stats= GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.health <= 0)
        {
          
        }
    }
}
