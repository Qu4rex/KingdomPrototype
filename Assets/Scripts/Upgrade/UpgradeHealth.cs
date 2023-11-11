using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : Upgrade
{
    private PlayerHealth _playerHealth;

    protected override void ApplyUpgrade()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _playerHealth?.AddMaxHealth(100);
        base.ApplyUpgrade();
    }
}
