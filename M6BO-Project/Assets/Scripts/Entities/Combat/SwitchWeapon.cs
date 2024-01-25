using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    public GameObject halberd;
    public GameObject sword;
    public GameObject currentWeapon;
    public bool canSwitch = true;
    private float delay = 0.5f;

    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
        currentWeapon = transform.GetChild(0).gameObject;
    }

    public void OnSwitch(InputAction.CallbackContext ctx)
    {
        float input = ctx.ReadValue<float>();
        if (!canSwitch) return;
        switch (input)
        {
            case -1:
                SwitchTo(halberd, sword, 1, 0);
                break;
            case 1:
                SwitchTo(sword, halberd, 0, 1);
                break;
        }
    }

    public void SwitchTo(GameObject weapon1, GameObject weapon2, int top, int bottom)
    {
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        currentWeapon = weapon1;
        SwitchLayers(top, bottom);
    }

    public void SwitchLayers(int top, int bottom)
    {
        _anim.SetLayerWeight(top, 1);
        _anim.SetLayerWeight(bottom, 0);
    }

    public IEnumerator SwitchDelay()
    {
        yield return new WaitForSeconds(delay);
    }

}
