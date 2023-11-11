using System;
using UnityEngine;

public class MineTower : Tower
{
    [SerializeField] private int _moneyPerSec;

    public static Action<int> onBuiltMine;

    protected override void Start()
    {
        base.Start();
        onBuiltMine?.Invoke(15);
    }
    protected override void Die()
    {
        base.Die();
        onBuiltMine?.Invoke(-15);
    }
}
