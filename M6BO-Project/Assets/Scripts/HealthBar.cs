using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider healthSlider;
    [SerializeField] private EntityStats healthStats;

    private void Start()
    {
        healthSlider.maxValue = healthStats.health;
    }

    private void Update()
    {
        healthSlider.value = healthStats.health;
    }
}
