using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpeed : Upgrade
{
    private PlayerController _playerController;

    protected override void ApplyUpgrade()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerController?.AddSpeed(1f);
        base.ApplyUpgrade();
    }
}
