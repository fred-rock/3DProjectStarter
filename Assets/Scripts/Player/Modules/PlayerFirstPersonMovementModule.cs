using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerFirstPersonMovementModule : BaseMovementModule, IPlayerModule // TODO: Make this use an interface, not a base class
{
    [SerializeField] private float _movementSpeed = 2.0f;
    private Player _player;
    private CharacterController _controller; // TODO: Set CharacterController values from PlayerData?
    private Vector3 _controllerVelocity;
    private Vector3 _horizontalVelocity;
    private float _currentSpeed;

    // Movement Vars
    private Vector3 _velocity;
    public float _gravity = -9.81f;
    private bool _grounded;

    // Crouch Vars
    private float _initHeight;
    [SerializeField] private float _crouchHeight;

    // jump vars
    private float _terminalVelocity = 53.0f;
    [SerializeField] private float _jumpHeight = 1.2f; // The height the player can jump
    [SerializeField] private float _jumpTimeout = 0.1f; // Time required to pass before being able to jump again. Set to 0f to instantly jump again
    [SerializeField] private float _fallTimeout = 0.15f; // Time required to pass before entering the fall state. Useful for walking down stairs
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    public GameObject _cinemachineCameraTarget; // Keep in Movement module, keep this in so that it can be moved with the crouch method

    private bool IsCurrentDeviceMouse // Make this actually check for the mouse
    {
        get
        {
            return true;
            //return _playerInput.currentControlScheme == "KeyboardMouse";
        }
    }

    public override void Initialize(Player player)
    {
        _player = player;
        _controller = GetComponent<CharacterController>();
        _initHeight = _controller.height;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _movementSpeed = _player.PlayerData.MoveSpeed;
    }

    private void Update()
    {
        CheckGround();

        CheckDownwardVelocity();

        JumpTimer();

        FallTimer();

        // current speed of character controller
        _controllerVelocity = _controller.velocity;
        _horizontalVelocity = new Vector3(_controller.velocity.x, 0, _controller.velocity.z);
        _currentSpeed = _horizontalVelocity.magnitude;

        //Debug.Log($"horizontal speed: {horizontalSpeed}, vertical speed: {verticalSpeed}, overall speed: {overallSpeed}");
    }

    public override void Move(Vector2 movementVector)
    {
        Vector3 moveInputDirection = transform.right * movementVector.x + transform.forward * movementVector.y;
        _controller.Move(moveInputDirection.normalized * _movementSpeed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime); // TODO: Work this into the above Move call
    }

    public override void Jump()
    {
        if (_grounded)
        {
            _fallTimeoutDelta = _fallTimeout;

            if (_jumpTimeoutDelta <= 0.0f)
            {
                // the square root of H * -2 * G = how much velocity needed to reach desired height
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }
        else
        {
            _jumpTimeoutDelta = _jumpTimeout;
        }

        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (_velocity.y < _terminalVelocity)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
    }

    public override void Crouch()
    {
        Debug.Log("trying to crouch");
    }

    public override float GetCurrentVelocity() // TODO: Fix this. It is not being called because the callers use the base class method.
    {
        //return _velocity.magnitude;
        return _currentSpeed;
    }

    private void CheckGround()
    {
        _grounded = _controller.isGrounded;
    }

    private void CheckDownwardVelocity()
    {
        if (_grounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }

    private void JumpTimer()
    {
        if (_jumpTimeoutDelta >= 0.0f)
        {
            _jumpTimeoutDelta -= Time.deltaTime;
        }
    }

    private void FallTimer()
    {
        if (_fallTimeoutDelta >= 0.0f)
        {
            _fallTimeoutDelta -= Time.deltaTime;
        }
    }

    //private void DoCrouch()
    //{
    //    if (inputActions.FPSController.Crouch.ReadValue<float>() > 0)
    //    {
    //        _controller.height = _crouchHeight;
    //    }
    //    else
    //    {
    //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 2.0f, -1))
    //        {
    //            _controller.height = _crouchHeight;
    //        }
    //        else
    //        {
    //            _controller.height = _initHeight;
    //        }
    //    }
    //}
}