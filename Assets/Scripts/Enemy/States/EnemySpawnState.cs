using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnState : IState
{
    private Enemy _enemy;

    public EnemySpawnState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public IEnumerator EntryState()
    {
        _enemy.SpawnModule.Respawn();
        _enemy.ModelAndAnimatorModule.ShowModel();
        yield return new WaitForSeconds(3);
        //_enemy.ChangeState(new EnemyWanderState(_enemy));
        _enemy.EnterWanderState();
    }

    public IEnumerator ExitState()
    {
        yield return null;
    }

    public void FixedUpdateState()
    {
    }

    public void UpdateState()
    {
    }
}
