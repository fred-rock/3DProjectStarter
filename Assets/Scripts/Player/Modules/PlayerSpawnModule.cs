using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnModule : MonoBehaviour, IPlayerModule
{
    private Player _player;
    private Vector3 _initialSpawnPoint;
    private Vector3 _lastCheckPoint;

    public void Initialize(Player player)
    {
        _player = player;
        _initialSpawnPoint = _player.transform.position;
    }

    public void Respawn()
    {
        if (_lastCheckPoint != Vector3.zero)
        {
            _player.transform.position = _lastCheckPoint;
        }
        else
        {
            _player.transform.position = _initialSpawnPoint;
        }
    }

    public void SetInitialSpawnPoint(Vector3 spawnPoint)
    {
        _initialSpawnPoint = spawnPoint;
    }

    public void SetLastCheckPoint(Vector3 checkPoint)
    {
        _lastCheckPoint = checkPoint;
    }
}
