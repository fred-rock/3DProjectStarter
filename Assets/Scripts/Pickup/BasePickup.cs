using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class BasePickup : MonoBehaviour
{
    [SerializeField] private AudioClip _pickupSFX;
    private Collider _collider;
    protected Player _player;
    protected SFXPlayer _sfxPlayer;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        _sfxPlayer = FindObjectOfType<SFXPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.gameObject.GetComponent<Player>();

            Pickup();
        }
    }

    public virtual void Pickup() { }

    protected void PlayPickupFX()
    {
        if (_sfxPlayer != null)
        {
            _sfxPlayer.PlaySFX(_pickupSFX);
        }
    }
}