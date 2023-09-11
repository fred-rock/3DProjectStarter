using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hitscan Weapon Data", menuName = "Game Data/New Hitscan Weapon Data")]
public class HitscanWeaponData : BaseWeaponData
{
    [SerializeField] private float _range = 1f;

    public float Range { get { return _range; } }
}