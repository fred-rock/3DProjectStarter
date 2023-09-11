using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectTargetModule : MonoBehaviour, IEnemyModule
{
    private float _range = 10f;
    private bool _isPlayerDetected;
    private Transform _target;
    private float _currentDistanceToTarget;
    private Enemy _enemy;
    private Player _player;

    public bool IsPlayerDetected { get { return _isPlayerDetected; } }
    public Transform Target { get { return _target; } }
    public float CurrentDistanceToTarget { get { return _currentDistanceToTarget; } }


    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _range = _enemy.EnemyData.DetectionRange;
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_isPlayerDetected)
        {
            _target = _player.transform;
        }

        if (_target != null)
        {
            GetCurrentDistanceToTarget(_target);
        }
    }

    public void Detect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _range);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                _isPlayerDetected = true;

                if (_enemy.FXModule != null)
                {
                    _enemy.FXModule.DetectPlayerFX();
                }
            }
        }
    }

    private void GetCurrentDistanceToTarget(Transform target)
    {
        _currentDistanceToTarget = Vector3.Distance(transform.position, target.position);
    }
}
