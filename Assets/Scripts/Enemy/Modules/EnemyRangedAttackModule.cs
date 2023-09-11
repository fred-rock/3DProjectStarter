using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttackModule : MonoBehaviour, IEnemyModule
{
    [SerializeField] private Projectile _projectile;
    private float _projectileSpeed = 5f;
    private int _damage = 3;
    private float _splashDamageRadius = 2f;
    private float _windupTime = 1f;
    private ObjectPool _objectPool;
    private bool _canAttack;
    private Enemy _enemy;

    public bool CanAttack { get { return _canAttack; } }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _projectileSpeed = _enemy.EnemyData.ProjectileSpeed;
        _damage = _enemy.EnemyData.RangedDamage;
        _windupTime = _enemy.EnemyData.RangedWindupTime;
        _canAttack = true;
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    public void RangedAttack(Transform target)
    {
        if (_canAttack)
        {
            _canAttack = false;

            StartCoroutine(RangedAttackCoroutine(target));
        }
    }

    private IEnumerator RangedAttackCoroutine(Transform target)
    {
        yield return new WaitForSeconds(_windupTime);
        FaceTarget(target);

        FireProjectile();

        if (_enemy.FXModule != null)
        {
            _enemy.FXModule.RangedAttackFX();
        }

        yield return null;
        _canAttack = true;
    }

    private void FaceTarget(Transform target) // TODO: Make less jerky? Move to move script
    {
        Vector3 targetDirection = target.position - transform.position;
        //Vector3.RotateTowards(_enemy.transform.position, target.position, 1f, 1f);
        _enemy.transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    private void FireProjectile()
    {
        Projectile projectile;
        if (_objectPool != null)
        {
            float speed = _enemy.MoveModule.GetCurrentVelocity() + _projectileSpeed;
            projectile = _objectPool.GetProjectile(speed, _damage, _splashDamageRadius, true, false, false, transform.position, transform.rotation);
        }
        else
        {
            projectile = Instantiate(_projectile, transform.position, transform.rotation);
        }
    }
}
