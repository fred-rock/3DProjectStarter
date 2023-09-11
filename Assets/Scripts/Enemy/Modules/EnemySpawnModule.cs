using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnModule : MonoBehaviour, IEnemyModule
{
    private Enemy _enemy;
    private Vector3 _initialSpawnPoint;

    public Vector3 InitialSpawnPoint { get { return _initialSpawnPoint; } }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _initialSpawnPoint = _enemy.transform.position;
    }

    public void Respawn()
    {
        _enemy.transform.position = _initialSpawnPoint;
    }

    public void SetInitialSpawnPoint(Vector3 spawnPoint)
    {
        _initialSpawnPoint = spawnPoint;
    }
}
