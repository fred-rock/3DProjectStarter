using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthModule : MonoBehaviour, IPlayerModule
{
    private Player _player;
    private int _currentHealth;

    public int CurrentHealth { get { return _currentHealth; } }

    public void Initialize(Player player)
    {
        _player = player;
        
        ResetHealth();
    }

    public void ResetHealth()
    {
        _currentHealth = _player.PlayerData.MaxHealth;
    }

    public void DecreaseCurrentHealth(int amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _player.PlayerData.MaxHealth);
    }

    public void IncreaseCurrentHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _player.PlayerData.MaxHealth);
    }

    public void IncreaseBonusHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _player.PlayerData.MaxBonusHealth);
    }
}
