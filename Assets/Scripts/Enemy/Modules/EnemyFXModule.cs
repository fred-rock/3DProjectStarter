using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyFXModule : MonoBehaviour, IEnemyModule
{
    [SerializeField] private ParticleSystem _gibs;
    private Enemy _enemy;
    private AudioSource _audioSource;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _audioSource = GetComponent<AudioSource>();
    }

    public void DetectPlayerFX()
    {
        _audioSource.clip = _enemy.EnemyData.DetectSound;
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

    public void RangedAttackFX()
    {
        _audioSource.clip = _enemy.EnemyData.RangedAttackSound;
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

    public void MeleeAttackFX()
    {
        _audioSource.clip = _enemy.EnemyData.MeleeAttackSound;
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

    public void HitFX()
    {
        //
    }

    public void DeathFX()
    {
        _audioSource.clip = _enemy.EnemyData.DeathSound;
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }

        if (!_gibs.isPlaying)
        {
            _gibs.Play();
        }
    }
}
