using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyHitboxModule : BaseDamageable, IEnemyModule
{
    private Collider _collider;
    private Rigidbody _rigidBody;
    private Enemy _enemy;
    private bool _isDamageable;
    private bool _isReceivingDamage;

    public override bool IsDamageable { get { return _isDamageable; } }
    public bool IsReceivingDamage { get { return _isReceivingDamage; } }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _collider = GetComponent<Collider>();
        _collider.isTrigger = false;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.isKinematic = false;
        _rigidBody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        _isDamageable = true;
        _isReceivingDamage = false;
        gameObject.layer = LayerMask.NameToLayer("Hitbox");
    }

    public override void AttemptDamage(int damage)
    {
        if (_isDamageable)
        {
            Damage(damage);
        }
    }

    public override void AttemptDamage(Projectile projectile)
    {
        if (_isDamageable && projectile.DamagesEnemy)
        {
            Damage(projectile.Damage);
        }
    }

    public override void Damage(int damage)
    {
        if (_enemy.HealthModule != null)
        {
            StartCoroutine(ReceivingDamageCoroutine());
            _enemy.HealthModule.Damage(damage);
        }
    }

    private IEnumerator ReceivingDamageCoroutine()
    {
        _isReceivingDamage = true;
        yield return new WaitForEndOfFrame();
        _isReceivingDamage = false;
    }
}