using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : BasePickup
{
    [SerializeField] private int _amount = 20;

    public override void Pickup()
    {
        if (_player.HealthModule != null && _player.PlayerData != null)
        {
            if (_player.HealthModule.CurrentHealth < _player.PlayerData.MaxHealth)
            {
                _player.HealthModule.IncreaseCurrentHealth(_amount);

                PlayPickupFX();

                Destroy(gameObject);
            }
        }

        base.Pickup();
    }
}