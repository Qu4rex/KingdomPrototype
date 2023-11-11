using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health;
    [SerializeField] private int _maxHealth;

    [Header("Effects")]
    [SerializeField] private GameObject _particle;

    private SpriteRenderer _spriteRenderer;
    public static Action<int, int> onChangedHealth;

    private void Start()
    {
        _health = _maxHealth;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        onChangedHealth?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(int _value)
    {
        if(_value >= 0)
        {
            _health -= _value;
            if(_health <= 0)
            {
                GameManager.Instance.Lose();
            }
        }

        onChangedHealth?.Invoke(_health, _maxHealth);

        StartCoroutine(FlashSpriteColor(Color.red, 0.15f));
        
    }

    public void AddMaxHealth(int value)
    {
        _maxHealth += value;
        _health = _maxHealth;
        onChangedHealth?.Invoke(_health, _maxHealth);
    }

    public void AddHealth()
    {
        if(_health < _maxHealth)
            _health++;

        onChangedHealth?.Invoke(_health, _maxHealth);
        Instantiate(_particle, transform.position, Quaternion.identity);
    }


    private IEnumerator FlashSpriteColor(Color color, float duration)
    {
        _spriteRenderer.color = color;
        yield return new WaitForSeconds(duration);
        _spriteRenderer.color = Color.white;
    }
}
