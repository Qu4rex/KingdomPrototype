using System;
using UnityEngine;

public class UpgradeSpiked : Upgrade
{
    public static Action onSpikedUpgraded;

    protected override void ApplyUpgrade()
    {
        onSpikedUpgraded?.Invoke();
        base.ApplyUpgrade();
    }
}
