using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthModule : MonoBehaviour, IEnemyModule
{
    private int _health = 1;
    private int _maxHealth = 1;
    private Enemy _enemy;

    public int Health { get { return _health; } }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _maxHealth = _enemy.EnemyData.MaxHealth;
        _health = _maxHealth;
    }

    public void Damage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }

    public void Heal(int heal)
    {
        _health += heal;
        _health = Mathf.Clamp(heal, 0, _maxHealth);
    }
}