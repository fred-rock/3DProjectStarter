using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFXModule : MonoBehaviour, IPlayerModule
{
    private Player _player;
    private AudioSource _audioSource;
    private HUDCanvas _hud;

    public void Initialize(Player player)
    {
        _player = player;
        _audioSource = GetComponent<AudioSource>();
        _hud = FindObjectOfType<HUDCanvas>();
    }

    public void JumpFX()
    {
        _audioSource.clip = _player.PlayerData.JumpSFX;
        if (!_audioSource.isPlaying )
        {
            _audioSource.Play();
        }
    }

    public void HurtFX()
    {
        _audioSource.clip = _player.PlayerData.HurtSFX;
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        if (_hud != null)
        {
            _hud.ShowHurtScreen();
        }
    }

    public void DeathFX()
    {
        _audioSource.clip = _player.PlayerData.DeathSFX;
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}