using System.Collections;
using UnityEngine;
using UnityEditor;

public class SpikedTower : Tower
{
    private float _damage;
    [SerializeField] private float _range;

    private void OnEnable() => UpgradeSpiked.onSpikedUpgraded += Upgrade;
    private void OnDisable() => UpgradeSpiked.onSpikedUpgraded -= Upgrade;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(GetEnemiesEverySecond());
    }

    private IEnumerator GetEnemiesEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _range);
            foreach(Collider2D enemy in enemies)
            {
                if(enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(1);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, _range);
    }

    private void Upgrade()
    {
        _damage += _damage/3;
    }
}
