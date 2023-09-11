using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : IState
{
    private Player _player;

    public PlayerDeathState(Player player)
    {
        _player = player;
    }

    public IEnumerator EntryState()
    {
        yield return null;
        _player.FXModule.DeathFX();
        _player.WeaponContainerModule.DeactivateAll();
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
        if (_player.InputModule.InteractAction.WasPerformedThisFrame())
        {
            _player.EnterSpawnState();
        }
    }
}
