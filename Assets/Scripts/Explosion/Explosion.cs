using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticles;
    private Vector3 _center;
    private float _radius = 1f;
    private int _damage = 1;

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.SendMessage("AddDamage");
        }
    }

    public void Initialize(Vector3 center, float radius, int damage)
    {
        _center = center;
        _radius = radius;
        _damage = damage;
    }

    public void Explode()
    {
        //if (other.gameObject.layer == LayerMask.NameToLayer("Hitbox"))
        //{
        //    BaseDamageable damageable = other.GetComponent<BaseDamageable>();
        //    if (damageable != null)
        //    {
        //        damageable.AttemptDamage(this);
        //    }
        //}

        Collider[] hitColliders = Physics.OverlapSphere(_center, _radius);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.SendMessage("AddDamage");
        }
    }
}
