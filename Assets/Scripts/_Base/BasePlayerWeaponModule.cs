using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerWeaponModule : MonoBehaviour
{
    protected BaseWeaponData _weaponData;
    public BaseWeaponData WeaponData { get { return _weaponData; } }
    public virtual void Initialize(Player player) { }
    public virtual void Unequip() { }
    public virtual void Equip() { }
    public virtual void Fire() { }
}