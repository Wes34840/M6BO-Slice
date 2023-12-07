using UnityEngine;
using UnityEngine.UI;

public class DisplayEntityPoise : MonoBehaviour
{
    public EntityPoise poiseScript;
    private Slider poiseSlider;
    void Start()
    {
        poiseSlider = GetComponent<Slider>();
        poiseSlider.maxValue = poiseScript.maxPoise;
    }

    void Update()
    {
        poiseSlider.value = poiseScript.CurrentPoise;
    }
}
