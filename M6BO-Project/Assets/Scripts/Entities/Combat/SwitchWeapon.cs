using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    public GameObject halberd;
    [SerializeField] private GameObject _sword;
    public GameObject currentWeapon;
    public bool canSwitch;
    private float delay = 0.5f;

    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
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
        _sword.SetActive(false);
        currentWeapon = halberd;
        SwitchLayers(1, 0);
    }

    public void SwitchToSword()
    {
        halberd.SetActive(false);
        _sword.SetActive(true);
        currentWeapon = _sword;
        SwitchLayers(0, 1);
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
