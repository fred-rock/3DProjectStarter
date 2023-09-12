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
        // Chase the target. Stop at melee range.
        //_enemy.MoveModule.Pursue(_enemy.DetectTargetModule.Target, _enemy.EnemyData.MeleeRange);
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

        // Chase the target. Stop at melee range.
        _enemy.MoveModule.Pursue(_enemy.DetectTargetModule.Target, _enemy.EnemyData.MeleeRange);

        // Check distance between enemy and target.
        float targetDistance = _enemy.DetectTargetModule.CurrentDistanceToTarget;

        // Pick a confrontation distance.
        float confrontationDistance = Random.Range(_enemy.EnemyData.MinimumRangedEngagementDistance, _enemy.EnemyData.MaximumRangedEngagementDistance);

        if (targetDistance < confrontationDistance)
        {
            _enemy.EnterRangedAttackState();
        }
    }

    public void FixedUpdateState() { }
}