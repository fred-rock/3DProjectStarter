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

        // Wander aimlessly
        _enemy.MoveModule.Wander();

        // Try to detect player
        _enemy.DetectTargetModule.Detect();
        bool isPlayerDetected = _enemy.DetectTargetModule.IsPlayerDetected;

        if (isPlayerDetected)
        {
            // Player enemy bark
            _enemy.FXModule.DetectPlayerFX();

            // Check distance between enemy and target.
            float targetDistance = _enemy.DetectTargetModule.CurrentDistanceToTarget;

            // If distance is between min and max ranged distance, switch to ranged attack.
            if (targetDistance > _enemy.EnemyData.MinimumRangedEngagementDistance && targetDistance < _enemy.EnemyData.MaximumRangedEngagementDistance)
            {
                _enemy.EnterRangedAttackState();
            }

            // If not, then switch to pursuit state.
            if (targetDistance > _enemy.EnemyData.MaximumRangedEngagementDistance)
            {
                _enemy.EnterPursuitState();
            }
        }
    }
}