using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    public float currentHealth
    {
        get
        {
            return GetHealth();
        }
        set
        {
            if (GetHealth() == value) return;
            currentHealth = value;
            if (OnVariableChange != null)
                OnVariableChange(currentHealth);
        }
    }
    public delegate void OnVariableChangeDelegate(float newVal);
    public OnVariableChangeDelegate OnVariableChange;

    [SerializeField] private Slider healthSlider;
    public EntityStats healthStats;

    private void Start()
    {
        OnVariableChange = OnHealthChange;
        healthSlider.maxValue = healthStats.maxHealth;
        healthSlider.value = healthStats.health;
        
    }

    public void OnHealthChange(float currentHealth)
    {
        UpdateHealth(currentHealth);
    }

    public void UpdateHealth(float current)
    {
        healthSlider.value = current;
    }

    public float GetHealth()
    {
        return healthStats.health;
    }
}
