using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlinchState : IState
{
    private Enemy _enemy;

    public EnemyFlinchState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public IEnumerator EntryState()
    {
        _enemy.MoveModule.Stop();
        yield return new WaitForSeconds(2f);

        _enemy.ChangeToPreviousState();
    }

    public IEnumerator ExitState()
    {
        Debug.Log($"Leaving flinch state.");
        yield return null;
    }

    public void FixedUpdateState() { }

    public void UpdateState()
    {
        if (_enemy.HealthModule.Health <= 0)
        {
            _enemy.EnterDeathState();
        }
    }
}
