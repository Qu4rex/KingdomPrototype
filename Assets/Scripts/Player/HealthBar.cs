using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealthBar;
    [SerializeField] private Text _healthText;

    private void OnEnable() => PlayerHealth.onChangedHealth += UpdateHealthBar;
    private void OndDisable() => PlayerHealth.onChangedHealth -= UpdateHealthBar;

    private void UpdateHealthBar(int _health, int _maxHealth)
    {
        _sliderHealthBar.maxValue = _maxHealth;
        _sliderHealthBar.value = _health;

        _healthText.text = _health.ToString() + " / " + _maxHealth.ToString();
    }
}
