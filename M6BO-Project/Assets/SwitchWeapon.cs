using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public List<RuntimeAnimatorController> controllers= new List<RuntimeAnimatorController>();
    public GameObject[] weapons;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
           
        }
    }
}
