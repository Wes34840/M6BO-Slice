using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChildCooldown : MonoBehaviour
{ 
    public void startCooldown()
    {
        StartCoroutine(GetComponentInChildren<EnemyMeleeAttack>().waitForCooldown());
    }

}
