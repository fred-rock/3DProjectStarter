using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponContainerModule : MonoBehaviour, IPlayerModule
{
    [SerializeField] private BasePlayerWeaponModule[] _weaponArray = new BasePlayerWeaponModule[9];
    private List<BasePlayerWeaponModule> _slottedWeapons = new List<BasePlayerWeaponModule>();
    private BasePlayerWeaponModule _currentWeapon;
    private BasePlayerWeaponModule _previousWeapon;
    private Player _player;
    private Transform _cameraTarget;
    private int _currentWeaponIndex;

    public BasePlayerWeaponModule CurrentWeapon { get { return _currentWeapon; } }

    public void Initialize(Player player)
    {
        _player = player;
        _cameraTarget = _player.FirstPersonLookModule.transform;
        transform.SetParent(_cameraTarget, true);

        foreach (BasePlayerWeaponModule weapon in _weaponArray)
        {
            if (weapon != null)
            {
                weapon.Initialize(player);
                _slottedWeapons.Add(weapon);
            }
        }

        _currentWeaponIndex = 0;
        _currentWeapon = _slottedWeapons[_currentWeaponIndex];
    }

    public void CycleWeapons()
    {
        DeactivateAll();

        _previousWeapon = _currentWeapon;
        _currentWeaponIndex++;

        if (_currentWeaponIndex >= _slottedWeapons.Count)
        {
            _currentWeaponIndex = 0;
        }

        ActivateWeaponAtIndex(_currentWeaponIndex);
    }

    public void EquipPrevious()
    {
        DeactivateAll();

        ActivateWeapon(_previousWeapon);
        _currentWeapon = _previousWeapon;
    }

    public void DeactivateAll()
    {
        foreach (BasePlayerWeaponModule weapon in _slottedWeapons)
        {
            weapon.Unequip();
        }
    }

    public void ActivateWeapon(BasePlayerWeaponModule weapon)
    {
        DeactivateAll();

        if (_slottedWeapons.Contains(weapon))
        {
            _currentWeapon = weapon;
            _currentWeapon.Equip();
        }
    }

    private void ActivateWeaponAtIndex(int index)
    {
        _currentWeapon = _slottedWeapons[_currentWeaponIndex];
        _currentWeapon.Equip();
    }

    public void FireCurrentWeapon()
    {
        if (_currentWeapon.enabled)
        {
            _currentWeapon.Fire();
        }
    }
}
