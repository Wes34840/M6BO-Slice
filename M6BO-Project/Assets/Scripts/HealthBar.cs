using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private EntityStats _entityStats;

    private void Start()
    {
        _healthSlider.maxValue = _entityStats.health;
    }

    private void Update()
    {
        _healthSlider.value = _entityStats.health;
    }

}
