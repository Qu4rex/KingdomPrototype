using UnityEngine;
using System;

public class ForgeTower : Tower
{
    public static Action onBuiltForge;

    protected override void Start()
    {
        base.Start();
        onBuiltForge?.Invoke();
    }
    protected override void Die()
    {
        base.Die();
        onBuiltForge?.Invoke();
    }
}
