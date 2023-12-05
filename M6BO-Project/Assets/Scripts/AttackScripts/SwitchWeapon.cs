using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public Animator weapons;
    public GameObject halberd;
    public GameObject sword;
    public bool CanSwitch;
    private float delay;
    
    
    private void Start()
    {
         weapons= GetComponentInParent<Animator>();  
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && CanSwitch == true)
        {
            halberd.SetActive(true);
            sword.SetActive(false);
            weapons.SetLayerWeight(0, 0);
            weapons.SetLayerWeight(1, 1);

            Debug.Log(weapons.GetLayerIndex("Sword"));

            
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CanSwitch == true)
        {
            halberd.SetActive(false);
            sword.SetActive(true);
            weapons.SetLayerWeight(0, 1);
            weapons.SetLayerWeight(1, 0);
            Debug.Log(weapons.GetLayerIndex("Halberd"));

        }
    }
}
