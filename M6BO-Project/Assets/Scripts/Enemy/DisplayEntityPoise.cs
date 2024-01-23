using UnityEngine;
using UnityEngine.UI;

public class DisplayEntityPoise : MonoBehaviour
{
    public EntityPoise poiseScript;
    private Slider _poiseSlider;

    void Start()
    {
        _poiseSlider = GetComponent<Slider>();
        _poiseSlider.maxValue = poiseScript.maxPoise;
    }

    void Update()
    {
        _poiseSlider.value = poiseScript.currentPoise;
    }

}
