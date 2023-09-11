using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : IState
{
    private Enemy _enemy;

    public EnemyDeathState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public IEnumerator EntryState()
    {
        if (_enemy.ModelAndAnimatorModule != null)
        {
            _enemy.ModelAndAnimatorModule.HideModel();
        }

        yield return null;

        if (_enemy.FXModule != null)
        {
            _enemy.FXModule.DeathFX();
        }

        yield return null;

        _enemy.StopStateMachine();
    }

    public IEnumerator ExitState()
    {
        yield return null;
    }

    public void FixedUpdateState() { }

    public void UpdateState() { }
}