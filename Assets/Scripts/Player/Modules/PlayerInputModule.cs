using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputModule : MonoBehaviour, IPlayerModule
{
    private Player _player;

    // TODO: Add in charged fire action, and crouch
    //[SerializeField] private bool _analogMovement;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _sprintActionValue;
    private InputAction _lookActionValue;
    private InputAction _jumpAction;
    private InputAction _interactAction;
    private InputAction _fireAction;
    private InputAction _weaponSwitchAction;
    private Vector2 _moveInputVector;
    private Vector2 _lookInputVector;

    //public bool AnalogMovement { get { return _analogMovement; } }
    public InputAction MoveAction { get { return _moveAction; } }
    public Vector2 MoveInputVector { get { return _moveInputVector; } }
    public Vector2 LookInputVector { get { return _lookInputVector; } }
    public bool SprintPressedThisFrame { get { return _sprintActionValue.WasPressedThisFrame(); } }
    public bool JumpPressedThisFrame { get { return _jumpAction.WasPressedThisFrame(); } }
    public bool InteractPressedThisFrame { get { return _interactAction.WasPressedThisFrame(); } }
    public InputAction JumpAction { get { return _jumpAction; } }
    public InputAction InteractAction { get { return _interactAction; } }
    public InputAction FireAction { get { return _fireAction; } }
    public InputAction WeaponSwitchAction { get { return _weaponSwitchAction; } }


    public void Initialize(Player player)
    {
        _player = player;
        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
        _sprintActionValue = _playerInput.actions["Sprint"];
        _lookActionValue = _playerInput.actions["Look"];
        _jumpAction = _playerInput.actions["Jump"];
        _interactAction = _playerInput.actions["Interact"];
        _fireAction = _playerInput.actions["Fire"];
        _weaponSwitchAction = _playerInput.actions["SwitchWeapon"];
    }

    public void OnMove(InputValue inputValue)
    {
        _moveInputVector = inputValue.Get<Vector2>();
    }

    public void OnLook(InputValue inputValue)
    {
        _lookInputVector = inputValue.Get<Vector2>();
    }

    //public void OnFire(InputValue inputValue) // WIP
    //{
    //    List<BasePlayerWeaponModule> weapons = new List<BasePlayerWeaponModule>();
    //    // Fill weapons list with child objects
    //    foreach (BasePlayerWeaponModule weapon in weapons)
    //    {
    //        if (weapon.enabled)
    //        {
    //            weapon.Fire();
    //        }
    //    }
    //}
}