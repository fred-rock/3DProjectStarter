using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeaponData : ScriptableObject
{
    [SerializeField] protected int _damage = 1;
    [SerializeField] protected float _fireRate = 1f;
    [SerializeField] protected AmmoType _ammoType;
    [SerializeField] protected int _fullClipSize = 10;
    [SerializeField] protected int _ammoConsumedPerSingleUse = 1;
    [SerializeField] protected AudioClip _equipSFX;
    [SerializeField] protected AudioClip _fireSFX;
    [SerializeField] protected AudioClip _clipEmptySFX;

    public int Damage { get { return _damage; } }
    public float FireRate { get { return _fireRate; } }
    public AmmoType AmmoType { get { return _ammoType; } }
    public int FullClipSize { get { return _fullClipSize; } }
    public int AmmoConsumedPerSingleUse { get { return _ammoConsumedPerSingleUse; } }
    public AudioClip EquipSFX { get { return _equipSFX; } }
    public AudioClip FireSFX { get { return _fireSFX; } }
    public AudioClip ClipEmptySFX { get { return _clipEmptySFX;} }
}