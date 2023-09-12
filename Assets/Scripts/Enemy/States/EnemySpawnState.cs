using System.Collections;
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
        // Return enemy to its original placement
        _enemy.SpawnModule.Respawn();

        // Activate the enemy's model
        _enemy.ModelAndAnimatorModule.ShowModel();
        
        yield return new WaitForSeconds(3);
        _enemy.EnterWanderState();
    }

    public IEnumerator ExitState()
    {
        yield return null;
    }

    public void FixedUpdateState() { }

    public void UpdateState() { }
}
