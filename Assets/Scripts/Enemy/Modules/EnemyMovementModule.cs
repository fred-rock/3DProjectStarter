using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovementModule : MonoBehaviour, IEnemyModule
{
    private enum MovementState
    {
        Stopped,
        Wander,
        Patrol,
        Pursue,
        Flee
    }

    [SerializeField] private List<Vector3> _waypoints; // TODO: Implement waypoints for Patrol behavior. Make "waypoints" or "enemy path" something the enemy gets from the level manager.
    [SerializeField] private float _wanderRange = 2f; // Is this useful to set on each object? Or should it come from EnemyData?
    private float _stopRange;
    private MovementState _movementState;
    private NavMeshAgent _agent;
    private Vector3 _destination;
    private Transform _target;
    private Vector3 _targetPosition;
    private LayerMask _groundMask;
    private Enemy _enemy;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _agent = GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = 1f;
        _movementState = MovementState.Stopped;
        _destination = _enemy.transform.position;
        _groundMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        UpdateTargetPosition();
        Debug.Log($"Current movement state: {_movementState}");

        switch (_movementState)
        {
            case MovementState.Stopped:
                ///
                break;
            case MovementState.Wander:
                if (Vector3.Distance(transform.position, _destination) <= .1f)
                {
                    _destination = GetWanderPoint();
                }
                break;
            case MovementState.Patrol:
                ///
                break;
            case MovementState.Pursue:
                _agent.SetDestination(_targetPosition);
                if (Vector3.Distance(transform.position, _targetPosition) <= _stopRange)
                {
                    _agent.velocity = Vector3.zero;
                    Debug.Log("Too close. SHould stop here.");
                }
                break;
            case MovementState.Flee:
                ///
                break;
            default:
                break;
        }
    }

    private void UpdateTargetPosition()
    {
        if (_target != null)
        {
            _targetPosition = _target.position;
        }
    }

    public float GetCurrentVelocity()
    {
        //return _agent.speed;
        return _agent.velocity.magnitude;
    }

    public void Stop()
    {
        _movementState = MovementState.Stopped;
        _agent.velocity = Vector3.zero;

        //_agent.velocity = Vector3.zero;
        //_agent.isStopped = true;
    }

    public void Patrol()
    {
        //_movementState = MovementState.Patrol;
        //_target = null;
        _agent.speed = _enemy.EnemyData.MoveSpeed;
        // TODO: Implement
    }

    public void Pursue(Transform target, float stopRange) // TODO: Add stop range (aka melee range) as argument
    {
        _movementState = MovementState.Pursue;
        _target = target;
        _stopRange = stopRange;
        _agent.speed = _enemy.EnemyData.PursueSpeed;

        //_agent.speed = _enemy.EnemyData.PursueSpeed;
        //_agent.SetDestination(target.position);
        //if (Vector3.Distance(transform.position, target.position) <= stopRange)
        //{
        //    _agent.velocity = Vector3.zero;
        //}
    }

    public void Flee(Transform target) 
    {
        //_movementState = MovementState.Flee;
        //_target = target;
        _agent.speed = _enemy.EnemyData.FleeSpeed;
    }

    public void Wander()
    {
        //_movementState = MovementState.Wander;
        //_target = null;
        _agent.speed = _enemy.EnemyData.MoveSpeed;

        //_agent.isStopped = false;
        //_agent.speed = _enemy.EnemyData.MoveSpeed;

        //if (_destination != null)
        //{
        //    _agent.SetDestination(_destination);
        //}
        //if (_destination == null || Vector3.Distance(transform.position, _destination) <= .1f)
        //{
        //    _destination = GetWanderPoint();
        //}
    }

    private Vector3 GetWanderPoint()
    {
        float randomZ = Random.Range(-_wanderRange, _wanderRange);
        float randomX = Random.Range(-_wanderRange, _wanderRange);

        Vector3 wanderPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // If wanderPoint is not on Ground layer, then return current position
        if (!Physics.Raycast(wanderPoint, -transform.up, 2f, _groundMask))
        {
            Debug.Log($"{wanderPoint} is not on ground layer. Finding a new wander point...");
            return transform.position;
        }
        else
        {
            return wanderPoint;
        }
    }
}
