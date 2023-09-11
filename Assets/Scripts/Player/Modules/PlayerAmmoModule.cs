using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoModule : MonoBehaviour, IPlayerModule
{
    [SerializeField] private List<AmmoType> _ammoTypes = new List<AmmoType>();
    private Player _player;
    private Dictionary<AmmoType, int> _currentReserves = new Dictionary<AmmoType, int>();

    public void Initialize(Player player)
    {
        _player = player;

        foreach (AmmoType reserve in _ammoTypes)
        {
            _currentReserves.Add(reserve, reserve.MaxAmount);
        }
    }

    public void Increase(AmmoType reserve, int amount)
    {
        if (_currentReserves.ContainsKey(reserve))
        {
            _currentReserves[reserve] += amount;
            _currentReserves[reserve] = Mathf.Clamp(amount, 0, reserve.MaxAmount);
        }
    }

    public void Decrease(AmmoType reserve, int amount)
    {
        if (_currentReserves.ContainsKey(reserve))
        {
            _currentReserves[reserve] -= amount;
            _currentReserves[reserve] = Mathf.Clamp(_currentReserves[reserve], 0, reserve.MaxAmount);
        }
    }

    public int GetCurrentAmount(AmmoType reserve)
    {
        if (_currentReserves.ContainsKey(reserve))
        {
            return _currentReserves[reserve];
        }
        else
        {
            return 0;
        }
    }
}
