using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private EntityStats health;
    
    void Start()
    {
        health= GetComponent<EntityStats>();
    }

    
    void Update()
    {
        if (health.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
