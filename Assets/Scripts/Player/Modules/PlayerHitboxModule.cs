using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class PlayerHitboxModule : BaseDamageable, IPlayerModule // TODO: Figure out how this can handle multiple "health types," i.e. shields, etc. Pass though a damage object instead?
{
    private Player _player;
    private Collider _collider;
    private bool _isDamageable;
    private bool _isReceivingDamage;

    public override bool IsDamageable { get { return _isDamageable; } }
    public bool IsReceivingDamage { get { return _isReceivingDamage; } }

    public void Initialize(Player player)
    {
        _player = player;
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Hitbox");
        _isDamageable = true;
        _isReceivingDamage = false;
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
        if (_isDamageable && projectile.DamagesPlayer)
        {
            Damage(projectile.Damage);
        }
    }

    public override void Damage(int damage)
    {
        if (_player.HealthModule != null)
        {
            StartCoroutine(ReceivingDamageCoroutine());
            _player.HealthModule.DecreaseCurrentHealth(damage);
        }
    }

    private IEnumerator ReceivingDamageCoroutine()
    {
        _isReceivingDamage = true;
        yield return new WaitForEndOfFrame();
        _isReceivingDamage = false;
    }
}