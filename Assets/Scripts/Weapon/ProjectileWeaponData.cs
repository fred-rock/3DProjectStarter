using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Weapon Data", menuName = "Game Data/New Projectile Weapon Data")]
public class ProjectileWeaponData : BaseWeaponData
{
    [SerializeField] private float _projectileSpeed = 1f;
    [SerializeField] private float _splashRadius = 1f;
    [SerializeField] private bool _damagesEnemy = true;
    [SerializeField] private bool _damagesPlayer = false;
    [SerializeField] private bool _damagesEnvironment = true;

    public float ProjectileSpeed { get { return _projectileSpeed; } }
    public float SplashRadius { get { return _splashRadius; } }
    public bool DamagesEnemy { get { return _damagesEnemy; } }
    public bool DamagesPlayer { get { return _damagesPlayer; } }
    public bool DamagesEnvironment { get { return _damagesEnvironment; } }
}