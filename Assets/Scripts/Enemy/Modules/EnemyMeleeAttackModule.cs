using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyMeleeAttackModule : MonoBehaviour, IEnemyModule
{
    private float _damage = 2f;
    private float _windupTime = 1f; // TODO: Tie this to the animation
    private Collider _collider;
    private bool _canAttack;
    private Enemy _enemy;

    public bool CanAttack { get { return _canAttack; } }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _damage = _enemy.EnemyData.MeleeDamage;
        _windupTime = _enemy.EnemyData.MeleeWindupTime;
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        _collider.enabled = false;
        _canAttack = true;
    }

    public void Melee()
    {
        if (_canAttack)
        {
            _canAttack = false;
            StartCoroutine(MeleeCoroutine());
        }
    }

    private IEnumerator MeleeCoroutine()
    {
        yield return new WaitForSeconds(_windupTime);
        _collider.enabled = true;

        if (_enemy.FXModule != null)
        {
            _enemy.FXModule.MeleeAttackFX();
        }

        yield return null;
        _collider.enabled = false;
        _canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}