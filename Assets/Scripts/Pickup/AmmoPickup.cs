using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : BasePickup
{
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _amount = 5;
    public override void Pickup()
    {
        if (_player.AmmoModule != null && _player.PlayerData != null)
        {
            int currentAmountHeld = _player.AmmoModule.GetCurrentAmount(_ammoType);
            if (currentAmountHeld < _ammoType.MaxAmount)
            {
                _player.AmmoModule.Increase(_ammoType, _amount);

                PlayPickupFX();

                Destroy(gameObject);
            }
        }

        base.Pickup();
    }
}
