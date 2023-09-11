using UnityEngine;

[CreateAssetMenu(fileName = "NewAmmoType", menuName = "Game Data/New Ammo Type")]
public class AmmoType : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _maxAmount = 100;

    public string Label { get { return _label; } }
    public int MaxAmount { get { return _maxAmount; } }
}