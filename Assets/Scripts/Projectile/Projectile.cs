using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private ParticleSystem _splashParticles;
    [SerializeField] private float _expirationTime = 5f;
    private float _speed = 3f;
    private int _damage = 2;
    private float _splashRadius = 1f;
    private Collider _collider;
    private bool _damagesPlayer;
    private bool _damagesEnemy;
    private bool _damagesEnvironment;
    private ObjectPool _objectPool;

    public int Damage { get { return _damage; } }
    public float SplashRadius { get { return _splashRadius; } }
    public bool DamagesPlayer { get { return _damagesPlayer; } }
    public bool DamagesEnemy { get {  return _damagesEnemy; } }
    public bool DamagesEnvironment { get { return _damagesEnvironment; } }

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    public void Initialize(float speed, int damage, float splashRadius, bool damagesPlayer, bool damagesEnemy, bool damagesEnvironment)
    {
        _speed = speed;
        _damage = damage;
        _splashRadius = splashRadius;
        _damagesPlayer = damagesPlayer;
        _damagesEnemy = damagesEnemy;
        _damagesEnvironment = damagesEnvironment;
        _collider = GetComponent<Collider>();
        gameObject.layer = LayerMask.NameToLayer("Projectile");
        _model.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(ExpireProjectileCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ExpireProjectileCoroutine());
    }

    private void Update()
    {
        if (_speed > 0)
        {
            MoveForward();
        }
    }

    private void MoveForward()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Projectile"))
        {
            if (_splashParticles != null)
            {
                StartCoroutine(ParticleSplashCoroutine());
            }
            else
            {
                DestroyProjectile();
            }

            GenerateSplashDamageSphere();
        }
    }

    private IEnumerator ParticleSplashCoroutine()
    {
        _model.gameObject.SetActive(false);
        _splashParticles.Play();
        float waitTime = _splashParticles.main.duration;
        yield return new WaitForSeconds(waitTime);
        DestroyProjectile();
    }

    private void GenerateSplashDamageSphere()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _splashRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (_damagesEnemy)
            {
                EnemyHitboxModule enemyHitbox = hitCollider.GetComponent<EnemyHitboxModule>();
                if (enemyHitbox != null)
                {
                    enemyHitbox.AttemptDamage(this);
                }
            }
            if (_damagesPlayer)
            {
                PlayerHitboxModule playerHitbox = hitCollider.GetComponent<PlayerHitboxModule>();
                if (playerHitbox != null)
                {
                    playerHitbox.AttemptDamage(this);
                }
            }
            if (_damagesEnvironment)
            {
                //
            }
        }
    }

    private void DestroyProjectile()
    {
        if (_objectPool != null)
        {
            _model.gameObject.SetActive(false);
            _objectPool.ReturnProjectile(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private IEnumerator ExpireProjectileCoroutine()
    {
        yield return new WaitForSeconds(_expirationTime);
        if (gameObject.activeSelf)
        {
            DestroyProjectile();
        }
    }
}