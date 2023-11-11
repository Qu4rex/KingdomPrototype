using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float _damage;
    [SerializeField] private float _arrowSpeed;

    private Transform _target;
    [SerializeField] private Rigidbody2D _rb;

    private void FixedUpdate()
    {
        if(_target == null) return;
        Vector2 dir = (_target.position - transform.position).normalized;
        _rb.velocity = dir * _arrowSpeed;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }   

    public void SetDamage(float value)
    {
        _damage = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage);
            Destroy(gameObject);
        }   
    }
}
