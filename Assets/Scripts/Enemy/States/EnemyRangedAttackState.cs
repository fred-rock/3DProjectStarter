using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttackState : IState
{
    private Enemy _enemy;

    public EnemyRangedAttackState(Enemy enemy)
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

        if (_enemy.DetectTargetModule.Target != null)
        {
            _enemy.RangedAttackModule.RangedAttack(_enemy.DetectTargetModule.Target);

            if (_enemy.DetectTargetModule.CurrentDistanceToTarget > _enemy.EnemyData.MaximumRangedEngagementDistance)
            {
                _enemy.EnterPursuitState();
            }
        }
    }

    public void FixedUpdateState()
    {
    }
}