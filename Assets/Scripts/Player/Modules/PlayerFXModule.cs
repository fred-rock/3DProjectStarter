using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFXModule : MonoBehaviour, IPlayerModule
{
    private Player _player;
    private AudioSource _audioSource;

    public void Initialize(Player player)
    {
        _player = player;
        _audioSource = GetComponent<AudioSource>();
    }

    public void JumpFX()
    {
        _audioSource.clip = _player.PlayerData.JumpSFX;
        if (!_audioSource.isPlaying )
        {
            _audioSource.Play();
        }
    }

    public void HitFX()
    {
        _audioSource.clip = _player.PlayerData.HitSFX;
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
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