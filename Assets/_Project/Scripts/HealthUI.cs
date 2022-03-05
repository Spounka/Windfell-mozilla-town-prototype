using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HealthSystem))]
public class HealthUI : MonoBehaviour
{
    [SerializeField] private Canvas uiCanvas;

    private HealthSystem _healthSystem;
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        uiCanvas ??= GetComponentInChildren<Canvas>();

        if (uiCanvas != null)
        {
            _healthSlider = uiCanvas.GetComponentInChildren<Slider>();
            _healthSlider.value = _healthSlider.maxValue = _healthSystem.MaxHealth;
        }
    }

    private void Update()
    {
        _healthSlider.value = _healthSystem.CurrentHealth;
    }
}