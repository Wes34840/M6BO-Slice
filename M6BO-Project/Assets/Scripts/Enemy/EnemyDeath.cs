using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private EntityStats _entityStats;

    void Start()
    {
        _entityStats = GetComponent<EntityStats>();
    }


    void Update()
    {
        if (_entityStats.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
