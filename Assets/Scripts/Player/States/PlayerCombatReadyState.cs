using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatReadyState : IState
{
    private Player _player;

    public PlayerCombatReadyState(Player player)
    {
        _player = player;
    }

    public IEnumerator EntryState()
    {
        _player.WeaponContainerModule.ActivateWeapon(_player.WeaponContainerModule.CurrentWeapon);
        yield return null;
    }

    public IEnumerator ExitState()
    {
        yield return null;
    }

    public void FixedUpdateState()
    {
        //
    }

    public void UpdateState()
    {

        _player.MovementModule.Move(_player.InputModule.MoveInputVector);
        _player.FirstPersonLookModule.Look(_player.InputModule.LookInputVector);

        if (_player.HitboxModule.IsReceivingDamage)
        {
            if (_player.HealthModule.CurrentHealth <= 0)
            {
                _player.EnterDeathState();
            }

            _player.FXModule.HitFX();
        }

        if (_player.InputModule.JumpAction.WasPerformedThisFrame())
        {
            _player.MovementModule.Jump();
            _player.FXModule.JumpFX();
        }

        if (_player.InputModule.WeaponSwitchAction.WasPerformedThisFrame())
        {
            _player.WeaponContainerModule.CycleWeapons();
        }

        if (_player.InputModule.FireAction.WasPerformedThisFrame())
        {
            if (_player.AmmoModule != null)
            {
                AmmoType ammoType = _player.WeaponContainerModule.CurrentWeapon.WeaponData.AmmoType;
                int ammoUsePerSingleUse = _player.WeaponContainerModule.CurrentWeapon.WeaponData.AmmoConsumedPerSingleUse;
                int currentAmmo = _player.AmmoModule.GetCurrentAmount(_player.WeaponContainerModule.CurrentWeapon.WeaponData.AmmoType);
                
                if (currentAmmo > 0)
                {
                    _player.WeaponContainerModule.CurrentWeapon.Fire();
                    _player.AmmoModule.Decrease(ammoType, ammoUsePerSingleUse);
                }
            }
        }
    }
}