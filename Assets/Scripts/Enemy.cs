using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private float _maxHealth;
    private float _health;

    [SerializeField] private float _moveSpeed = 3f;

    private float _delay = 1f;

    private Transform _player;
    private Rigidbody2D _rb;

    private Coroutine _attackPlayerCoroutine;
    private Coroutine _attackTowerCoroutine;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _health = _maxHealth;
        _sliderHealth.maxValue = _maxHealth;
        _sliderHealth.value = _health;
        _sliderHealth.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = direction * _moveSpeed;
    }

    public void TakeDamage(float _damage)
    {
        if(_damage > 0)
        {
            _health -= _damage;
            _sliderHealth.value = _health;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
            _sliderHealth.gameObject.SetActive(true);
        }
    }

    #region Triggers and Attacks
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _moveSpeed = 0f;
            _attackPlayerCoroutine = StartCoroutine(AttackPlayer(other));
        }
        if (other.gameObject.tag == "Tower")
        {
            _moveSpeed = 0f;
            _attackTowerCoroutine = StartCoroutine(AttackTower(other));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(_attackPlayerCoroutine);
            _moveSpeed = 3f;
        }
        if (other.gameObject.tag == "Tower")
        {
            StopCoroutine(_attackTowerCoroutine);
            _moveSpeed = 3f;
        }
    }

    private IEnumerator AttackPlayer(Collider2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        while(true)
        {
            yield return new WaitForSeconds(_delay/2);
            playerHealth.TakeDamage(5);
        }
    }
    private IEnumerator AttackTower(Collider2D other)
    {
        Tower tower = other.gameObject.GetComponent<Tower>();
        while(true)
        {
            yield return new WaitForSeconds(_delay);
            tower.TakeDamage(5f);
        }
    }
    #endregion
}
