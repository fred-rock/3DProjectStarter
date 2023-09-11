using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Game Data/New Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string _type = "Enemy";
    [SerializeField] private int _maxHealth = 25;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _pursueSpeed = 3f;
    [SerializeField] private float _fleeSpeed = 3f;
    [SerializeField] private float _detectionRange = 10f;
    [SerializeField] private bool _hasRangedAttack = true;
    [SerializeField] private float _projectileSpeed = 5f;
    [SerializeField] private int _rangedDamage = 3;
    [SerializeField] private float _rangedWindupTime = 1f;
    [SerializeField] private float _minimumRangedEngagementDistance = 5f;
    [SerializeField] private float _maximumRangedEngagementDistance = 15f;
    [SerializeField] private bool _hasMeleeAttack = true;
    [SerializeField] private float _meleeDamage = 3f;
    [SerializeField] private float _meleeWindupTime = 1f;
    [SerializeField] private float _meleeRange = 1f;
    [SerializeField] private AudioClip _rangedAttackSound;
    [SerializeField] private AudioClip _meleeAttackSound;
    [SerializeField] private AudioClip _detectSound;
    [SerializeField] private AudioClip _deathSound;

    public string Type { get { return _type; } }
    public int MaxHealth { get { return _maxHealth; } }
    public float MoveSpeed { get { return _moveSpeed; } }
    public float PursueSpeed { get { return _pursueSpeed; } }
    public float FleeSpeed { get { return _fleeSpeed; } }
    public float DetectionRange { get { return _detectionRange; } }
    public bool HasRangedAttack { get { return _hasRangedAttack; } }
    public float ProjectileSpeed { get { return _projectileSpeed; } }
    public int RangedDamage { get { return _rangedDamage; } }
    public float RangedWindupTime { get { return _rangedWindupTime; } }
    public float MinimumRangedEngagementDistance { get { return _minimumRangedEngagementDistance; } }
    public float MaximumRangedEngagementDistance { get { return _maximumRangedEngagementDistance; } }
    public bool HasMeleeAttack { get { return _hasMeleeAttack; } }
    public float MeleeDamage { get { return _meleeDamage; } }
    public float MeleeWindupTime { get { return _meleeWindupTime; } }
    public float MeleeRange { get { return _meleeRange; } }
    public AudioClip RangedAttackSound { get { return _rangedAttackSound;} }
    public AudioClip MeleeAttackSound { get { return _meleeAttackSound;} }
    public AudioClip DetectSound { get { return _detectSound;} }
    public AudioClip DeathSound { get { return _deathSound;} }
}