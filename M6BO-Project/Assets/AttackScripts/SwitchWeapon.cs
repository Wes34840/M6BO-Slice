using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapon : MonoBehaviour
{
    public Animator weapons;
    public GameObject halberd;
    public GameObject sword;
    public GameObject currentWeapon;
    public bool canSwitch;
    private float delay;


    private void Start()
    {
        weapons = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        
    }

    public void OnSwitch(InputAction.CallbackContext ctx)
    {
        float input = ctx.ReadValue<float>();
        if (!canSwitch) return;
        switch (input)
        {
            case -1:
                SwitchToHalberd();
                break;
            case 1:
                SwitchToSword();
                break;
        }
    }

    public void SwitchToHalberd()
    {
        halberd.SetActive(true);
        sword.SetActive(false);
        currentWeapon = halberd;
        weapons.SetLayerWeight(0, 0);
        weapons.SetLayerWeight(1, 1);

    }
    public void SwitchToSword()
    {
        halberd.SetActive(false);
        sword.SetActive(true);
        currentWeapon = sword;
        weapons.SetLayerWeight(0, 1);
        weapons.SetLayerWeight(1, 0);
    }

    public IEnumerator SwitchDelay()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
