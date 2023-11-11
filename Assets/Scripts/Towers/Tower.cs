using System;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    protected float _health;
    [SerializeField] protected float _maxHealth;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text _healthText;

    private void OnEnable() => ForgeTower.onBuiltForge += UpdateHealth;
    private void OnDisable() => ForgeTower.onBuiltForge -= UpdateHealth;

    protected virtual void Start()
    {
        _health = _maxHealth;
        UpdateHealth();
    }

    public void TakeDamage(float _value)
    {
        if(_value >= 0)
        {
            _health -= _value;
            if(_health <= 0)
                Die();
        }
        _healthBar.value = _health;
        _healthText.text = _health.ToString() + " / " + _maxHealth.ToString();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    private void UpdateText()
    {
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _health;
        _healthText.text = _health.ToString() + " / " + _maxHealth.ToString();
    }

    private void UpdateHealth()
    {
        int amountForgeTowers = FindObjectsOfType<ForgeTower>().Length;

        if(_health == _maxHealth){
            _maxHealth *= amountForgeTowers + 1;
            _health = _maxHealth;
        }else{
            _maxHealth *= amountForgeTowers + 1;
        }

        UpdateText();
    }
}
