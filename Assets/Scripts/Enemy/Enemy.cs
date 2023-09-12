using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IStateMachine
{
    [SerializeField] private EnemyData _enemyData;
    private IState _currentState;
    private IState _previousState;
    
    public EnemySpawnModule SpawnModule;
    public EnemyMovementModule MoveModule;
    public EnemyModelAndAnimatorModule ModelAndAnimatorModule;
    public EnemyHitboxModule HitboxModule;
    public EnemyDetectTargetModule DetectTargetModule;
    public EnemyHealthModule HealthModule;
    public EnemyMeleeAttackModule MeleeModule;
    public EnemyRangedAttackModule RangedAttackModule;
    public EnemyFXModule FXModule;

    public EnemySpawnState SpawnState;
    public EnemyWanderState WanderState;
    public EnemyPursuitState PursuitState;
    public EnemyPatrolState PatrolState;
    public EnemyRangedAttackState RangedAttackState;

    public EnemyData EnemyData { get { return _enemyData; } }
    public IState CurrentState {get { return _currentState; } }

    private void Awake()
    {
        MoveModule = GetComponent<EnemyMovementModule>();
        SpawnModule = GetComponentInChildren<EnemySpawnModule>();
        ModelAndAnimatorModule = GetComponentInChildren<EnemyModelAndAnimatorModule>();
        HitboxModule = GetComponentInChildren<EnemyHitboxModule>();
        HealthModule = GetComponentInChildren<EnemyHealthModule>();
        DetectTargetModule = GetComponentInChildren<EnemyDetectTargetModule>();
        MeleeModule = GetComponentInChildren<EnemyMeleeAttackModule>();
        RangedAttackModule = GetComponentInChildren<EnemyRangedAttackModule>();
        FXModule = GetComponentInChildren<EnemyFXModule>();

        Initialize();

        EnterSpawnState();
    }

    public void Initialize()
    {
        MoveModule.Initialize(this);  
        SpawnModule.Initialize(this);
        ModelAndAnimatorModule.Initialize(this);
        HitboxModule.Initialize(this);
        HealthModule.Initialize(this);
        DetectTargetModule.Initialize(this);
        MeleeModule.Initialize(this);
        RangedAttackModule.Initialize(this);
        FXModule.Initialize(this);
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.UpdateState();
            // Debug.Log($"Current state {_currentState}");
        }
    }

    private void FixedUpdate()
    {
        if (_currentState != null)
        {
            _currentState.FixedUpdateState();
        }
    }

    public void ChangeState(IState state)
    {
        StartCoroutine(_currentState.ExitState());

        _previousState = _currentState;
        _currentState = state;

        StartCoroutine(_currentState.EntryState());
    }

    public void ChangeToPreviousState()
    {
        Debug.Log($"Previous state is: {_previousState}. Current state is {_currentState}");
        ChangeState(_previousState);
    }

    public void EnterSpawnState()
    {
        _currentState = new EnemySpawnState(this);
        ChangeState(_currentState);
    }

    public void EnterWanderState()
    {
        ChangeState(new EnemyWanderState(this));
    }

    public void EnterPatrolState()
    {
        ChangeState(new EnemyPatrolState(this));
    }

    public void EnterPursuitState()
    {
        ChangeState(new EnemyPursuitState(this));
    }

    public void EnterRangedAttackState()
    {
        ChangeState(new EnemyRangedAttackState(this));
    }

    public void EnterMeleeAttackState()
    {
        //
    }

    public void EnterFlinchState()
    {
        if (_currentState.GetType() != typeof(EnemyFlinchState))
        {
            ChangeState(new EnemyFlinchState(this));
        }
    }

    public void EnterDeathState()
    {
        if (_currentState.GetType() != typeof(EnemyDeathState))
        {
            ChangeState(new EnemyDeathState(this));
        }
    }

    public void StopStateMachine()
    {
        StopAll();
        StopAllCoroutines();
        _currentState = null;
        _previousState = null;
    }

    public void StopAll()
    {
        MoveModule.StopAllCoroutines();
        SpawnModule.StopAllCoroutines();
        HitboxModule.StopAllCoroutines();
        HealthModule.StopAllCoroutines();
        DetectTargetModule.StopAllCoroutines();
        MeleeModule.StopAllCoroutines();
        RangedAttackModule.StopAllCoroutines();
        FXModule.StopAllCoroutines();
    }
}