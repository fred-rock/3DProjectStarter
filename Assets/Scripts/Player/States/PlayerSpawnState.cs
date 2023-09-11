using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnState : IState
{
    Player _player;

    public PlayerSpawnState(Player player)
    {
        _player = player;
    }

    public IEnumerator EntryState()
    {
        _player.WeaponContainerModule.DeactivateAll();
        _player.SpawnModule.Respawn();
        _player.HealthModule.ResetHealth();
        
        yield return new WaitForSeconds(3);
        _player.ChangeState(new PlayerCombatReadyState(_player));
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
        //
    }
}
