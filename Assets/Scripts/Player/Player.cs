using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IStateMachine
{
    [SerializeField] private PlayerData _playerData;
    private IState _currentState;
    private IState _previousState;

    public PlayerInputModule InputModule;
    public PlayerSpawnModule SpawnModule;
    public PlayerFirstPersonLookModule FirstPersonLookModule;
    public PlayerHitboxModule HitboxModule;
    public BaseMovementModule MovementModule;
    public PlayerWeaponContainerModule WeaponContainerModule;
    public PlayerGroundCheckModule GroundCheckModule;
    public PlayerHealthModule HealthModule;
    public PlayerAmmoModule AmmoModule;
    public PlayerFXModule FXModule;

    public PlayerSpawnState SpawnState;
    public PlayerCombatReadyState CombatReadyState;
    public PlayerDeathState DeathState;

    public PlayerData PlayerData { get { return _playerData; } }    
    public IState CurrentState { get { return _currentState; } }

    private void Awake()
    {
        InputModule = GetComponentInChildren<PlayerInputModule>();
        SpawnModule = GetComponentInChildren<PlayerSpawnModule>();
        FirstPersonLookModule = GetComponentInChildren<PlayerFirstPersonLookModule>();
        HitboxModule = GetComponentInChildren<PlayerHitboxModule>();
        MovementModule = GetComponentInChildren<BaseMovementModule>();
        GroundCheckModule = GetComponentInChildren<PlayerGroundCheckModule>();
        HealthModule = GetComponentInChildren<PlayerHealthModule>();
        AmmoModule = GetComponentInChildren<PlayerAmmoModule>();
        WeaponContainerModule = GetComponentInChildren<PlayerWeaponContainerModule>();
        FXModule = GetComponentInChildren<PlayerFXModule>();

        Initialize();

        _currentState = new PlayerSpawnState(this);
        ChangeState(_currentState);
    }

    public void Initialize()
    {      
        InputModule.Initialize(this);       
        SpawnModule.Initialize(this);       
        FirstPersonLookModule.Initialize(this);       
        HitboxModule.Initialize(this);       
        MovementModule.Initialize(this);       
        GroundCheckModule.Initialize(this);
        HealthModule.Initialize(this);
        AmmoModule.Initialize(this);
        WeaponContainerModule.Initialize(this);
        FXModule.Initialize(this);
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
        ChangeState(_previousState);
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void EnterSpawnState()
    {
        ChangeState(new PlayerSpawnState(this));
    }

    public void EnterCombatReadyState()
    {
        ChangeState(new PlayerCombatReadyState(this));
    }

    public void EnterDeathState()
    {
        ChangeState(new PlayerDeathState(this));
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
        InputModule.StopAllCoroutines();
        SpawnModule.StopAllCoroutines();
        FirstPersonLookModule.StopAllCoroutines();
        HitboxModule.StopAllCoroutines();
        MovementModule.StopAllCoroutines();
        GroundCheckModule.StopAllCoroutines();
        HealthModule.StopAllCoroutines();
        AmmoModule.StopAllCoroutines();
        WeaponContainerModule.StopAllCoroutines();
        FXModule.StopAllCoroutines();
    }
}
