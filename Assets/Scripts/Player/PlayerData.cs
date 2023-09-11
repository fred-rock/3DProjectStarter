using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Game Data/New Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Basic settings")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _maxBonusHealth = 200;
    [Header("Movement settings")]
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _sprintSpeed = 15f;
    [SerializeField] private float _crouchHeight = 1f;
    [SerializeField] private float _gravity = -9.81f;
    [Header("SFX")]
    [SerializeField] private AudioClip _jumpSFX;
    [SerializeField] private AudioClip _hitSFX;
    [SerializeField] private AudioClip _deathSFX;

    //[Header("Character Controller settings")]
    //[SerializeField] private float _slopeLimit = 45f;
    //[SerializeField] private float _stepOffset = 0.5f;
    //[SerializeField] private float _skinWidth = 0.08f;
    //[SerializeField] private float _minMoveDistance = 0.001f;
    //[SerializeField] private Vector3 _center = Vector3.zero;
    //[SerializeField] private float _radius = 0.5f;
    //[SerializeField] private float _height = 2f;

    public float MoveSpeed { get { return _moveSpeed; } }
    public float SprintSpeed { get { return _sprintSpeed; } }
    public int MaxHealth { get { return _maxHealth; } }
    public int MaxBonusHealth { get { return _maxBonusHealth; } }
    public float CrouchHeight { get {  return _crouchHeight; } }
    public float Gravity { get { return _gravity; } }
    //public float SlopeLimit { get { return _slopeLimit; } } 
    //public float StepOffset { get { return _stepOffset; } }
    //public float SkinWidth { get { return _skinWidth; } }
    //public float MinMoveDistance { get { return _minMoveDistance; } }
    //public Vector3 Center { get { return _center; } }
    //public float Radius { get { return _radius; } }
    //public float Height { get { return _height;} }
    public AudioClip JumpSFX { get { return _jumpSFX; } }
    public AudioClip HitSFX { get { return _hitSFX; } }
    public AudioClip DeathSFX { get { return _deathSFX; } }
}