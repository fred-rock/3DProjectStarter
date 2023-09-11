using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour // TODO: Make this optionally auto-expand if there are more objects needed than pool size
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private int _poolSize = 50;
    private List<Projectile> _projectilePool = new List<Projectile>();
    private List<Projectile> _projectilesInUse = new List<Projectile>();

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i  = 0; i < _poolSize; i++)
        {
            Projectile projectile = Instantiate(_projectilePrefab, transform);
            projectile.gameObject.SetActive(false);
            _projectilePool.Add(projectile);
        }
    }

    public Projectile GetProjectile(float speed, int damage, float splashDamage, bool damagesPlayer, bool damagesEnemy, bool damagesEnvironment, Vector3 position, Quaternion rotation)
    {
        Projectile projectile = _projectilePool[0];
        _projectilePool.RemoveAt(0);
        _projectilesInUse.Add(projectile);

        projectile.Initialize(speed, damage, splashDamage, damagesPlayer, damagesEnemy, damagesEnvironment);
        projectile.transform.SetPositionAndRotation(position, rotation);
        projectile.gameObject.SetActive(true);

        return projectile;
    }

    public void ReturnProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        if (_projectilesInUse.Contains(projectile))
        {
            _projectilesInUse.Remove(projectile);
            _projectilePool.Add(projectile);
        }
    }
}