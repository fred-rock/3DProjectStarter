using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour // This is a total WIP right now
{
    private Transform _doorTransform;
    private float _yScaleClosed;
    private float _yScaleOpen = 0f;
    private bool _isOpen;

    private void Awake()
    {
        _doorTransform = GetComponent<Transform>();
        _yScaleClosed = _doorTransform.transform.localScale.y;
        _isOpen = false;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!_isOpen)
            {
                _doorTransform.localScale = new Vector3(_doorTransform.localScale.x, _yScaleOpen, _doorTransform.localScale.z);
                _isOpen = true;
            }
            else
            {
                _doorTransform.localScale = new Vector3(_doorTransform.localScale.x, _yScaleClosed, _doorTransform.localScale.z);
                _isOpen = false;
            }
        }

    }
}
