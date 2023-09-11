using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamageable : MonoBehaviour, IDamageable
{
    //protected bool _isDamageable;
    public virtual bool IsDamageable { get; }
    public virtual void AttemptDamage(int damage) { }
    public virtual void AttemptDamage(Projectile projectile) { }
    public virtual void Damage(int damage) { }
}