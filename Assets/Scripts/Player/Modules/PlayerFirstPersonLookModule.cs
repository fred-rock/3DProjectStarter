using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirstPersonLookModule : MonoBehaviour, IPlayerModule
{
    [SerializeField] private Transform _cinemachineCameraTarget;
    [SerializeField] private float _lookSensitivity = 1f;
    private float _cinemachineTargetPitch;
    [SerializeField] private float _bottomClamp = -90f;
    [SerializeField] private float _topClamp = 90f;
    private const float _threshold = 0.01f;
    private Player _player;

    // For zoom
    public Camera _camera;
    public float _zoomFOV = 35.0f;
    public float _zoomSpeed = 9f;
    private float _targetFOV;
    private float _baseFOV;

    public Transform CinemachineCameraTarget { get { return _cinemachineCameraTarget; } }

    private bool IsCurrentDeviceMouse // Make this actually check for the mouse
    {
        get
        {
            return true;
            //return _playerInput.currentControlScheme == "KeyboardMouse";
        }
    }

    //private void Update()
    //{
    //    Look(_player.InputModule.LookInputVector);
    //}

    public void Initialize(Player player)
    {
        _player = player;
        _player = GetComponentInParent<Player>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Look()
    {
        if (_player != null && _player.InputModule.LookInputVector.sqrMagnitude >= _threshold)
        {
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetPitch += _player.InputModule.LookInputVector.y * _lookSensitivity * deltaTimeMultiplier;

            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _bottomClamp, _topClamp);

            _cinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0f, 0f);

            _player.transform.Rotate(Vector3.up * _player.InputModule.LookInputVector.x * _lookSensitivity * deltaTimeMultiplier);
        }
    }

    public void Look(Vector2 inputVector) // Called by state machine
    {
        if (_player != null && inputVector.sqrMagnitude >= _threshold)
        {
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetPitch += inputVector.y * _lookSensitivity * deltaTimeMultiplier;

            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _bottomClamp, _topClamp);

            _cinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0f, 0f);

            _player.transform.Rotate(Vector3.up * inputVector.x * _lookSensitivity * deltaTimeMultiplier);
        }
    }

    //private void DoZoom()
    //{
    //    if (inputActions.FPSController.Zoom.ReadValue<float>() > 0)
    //    {
    //        _targetFOV = _zoomFOV;
    //    }
    //    else
    //    {
    //        _targetFOV = _baseFOV;
    //    }
    //    UpdateZoom();
    //}

    //private void UpdateZoom() // TODO: Integrate this with Cinemachine
    //{
    //    _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, _targetFOV, _zoomSpeed * Time.deltaTime);
    //}

    //public void SetBaseFOV(float fov) // TODO: Integrate this with Cinemachine
    //{
    //    _baseFOV = fov;
    //}

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}