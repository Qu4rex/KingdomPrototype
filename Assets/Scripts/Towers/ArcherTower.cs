using UnityEngine;
using UnityEditor;

public class ArcherTower : Tower
{
    [SerializeField] private float _damage;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private float _targetingRange;
    [SerializeField] private LayerMask _enemyMask;
    
    private Transform _target;

    [SerializeField] private float _shootingRate;
    private float _shootCooldown = 0.0f;

    private bool CanAttack => _shootCooldown <= 0.0f;
    private bool CheckTargetIsInRange => Vector2.Distance(_target.position, transform.position) <= _targetingRange;

    private void OnEnable() => UpgradeArcher.onArcherUpgraded += UpgradeTower;
    private void OnDisable() => UpgradeArcher.onArcherUpgraded -= UpgradeTower;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(_shootCooldown > 0)
            _shootCooldown -= Time.deltaTime;

        if(_target == null)
        {
            FindTarget();
            return;
        }
        
        if(!CheckTargetIsInRange)
            _target = null;
        else
            Shoot();
    }

    private void Shoot()
    {
        if(CanAttack)
        {
            _shootCooldown = _shootingRate;
            GameObject arrowObject = Instantiate(_arrow, _shotPoint.position, Quaternion.identity);
            Arrow arrow = arrowObject.GetComponent<Arrow>();
            arrow.SetTarget(_target);
            arrow.SetDamage(_damage);
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _targetingRange, (Vector2)transform.position, 0f, _enemyMask);

        if(hits.Length > 0)
        {
            _target = hits[0].transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, _targetingRange);
    }
    
    private void UpgradeTower()
    {
        _damage += _damage/3;
    }
}
