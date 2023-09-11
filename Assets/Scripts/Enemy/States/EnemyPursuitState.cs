using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuitState : IState
{
    private Enemy _enemy;

    public EnemyPursuitState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public IEnumerator EntryState()
    {
        yield return null;
        _enemy.MoveModule.Pursue(_enemy.DetectTargetModule.Target, _enemy.EnemyData.MeleeRange);
    }

    public IEnumerator ExitState()
    {
        yield return null;
    }

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

        // TODO: Add a "confrontation range" variable - a number between minimum stopping distance and maximum. Pick range randomly. Once the enemy stops, then evaluate which state to transition to.

        //if (_enemy.DetectTargetModule.CurrentDistanceToTarget >= _enemy.EnemyData.MinimumRangedEngagementDistance && _enemy.DetectTargetModule.CurrentDistanceToTarget < _enemy.EnemyData.MaximumRangedEngagementDistance)
        //{
        //    _enemy.EnterRangedAttackState();
        //}
        
        //_enemy.MoveModule.Pursue(_enemy.DetectTargetModule.Target, _enemy.EnemyData.MeleeRange);
    }

    public void FixedUpdateState() { }
}