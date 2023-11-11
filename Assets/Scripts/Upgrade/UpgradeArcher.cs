using UnityEngine;
using System;

public class UpgradeArcher : Upgrade
{
    public static Action onArcherUpgraded;

    protected override void ApplyUpgrade()
    {
        onArcherUpgraded?.Invoke();
        base.ApplyUpgrade();
    }
}
