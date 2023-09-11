using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheckModule : MonoBehaviour, IPlayerModule // TODO: Make this check ground for surface type, e.g. lava, water, etc. Movement/jump ground check is currently handled by the CharacterController
{
    [SerializeField] private Transform _groundPositionTransform;
    [SerializeField] private float _groundCheckDepth = 1f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;
    private Player _player;
    public bool IsGrounded { get { return _isGrounded; } }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        Vector3 groundPosition = _groundPositionTransform.position;
        if (Physics.Raycast(groundPosition, -transform.up, _groundCheckDepth, _groundLayer))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}