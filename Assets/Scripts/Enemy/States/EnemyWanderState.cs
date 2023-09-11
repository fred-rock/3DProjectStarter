using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderState : IState
{
    private Enemy _enemy;

    public EnemyWanderState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public IEnumerator EntryState()
    {
        yield return null;
    }

    public IEnumerator ExitState()
    {
        yield return null;
    }

    public void FixedUpdateState() { }

    public void UpdateState()
    {
        if (_enemy.HealthModule.Health <= 0)
        {
            _enemy.EnterDeathState();
        }

        if (_enemy.HitboxModule.IsReceivingDamage)
        {
            _enemy.EnterFlinchState();
        }

        _enemy.MoveModule.Wander();
        _enemy.DetectTargetModule.Detect();

        // TODO: Check distance between enemy and target. If distance is between min and max ranged distance, switch to ranged attack. If not, then switch to pursuit state.

        if (_enemy.DetectTargetModule.IsPlayerDetected)
        {
            _enemy.FXModule.DetectPlayerFX();

            _enemy.EnterPursuitState();
        }
    }
}