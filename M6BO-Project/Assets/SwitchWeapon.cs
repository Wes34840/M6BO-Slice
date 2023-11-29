using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public List<RuntimeAnimatorController> controllers= new List<RuntimeAnimatorController>();
    public GameObject[] weapons;
    GameObject currentWeapon;
    private void Start()
    {
        currentWeapon = weapons[0];
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentWeapon = weapons[1];
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentWeapon = weapons[0];
           
        }
    }
}
