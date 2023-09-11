using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    private AudioSource _sfxAudioSource;

    private void Awake()
    {
        _sfxAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        _sfxAudioSource.PlayOneShot(audioClip);
    }

    public void PlaySFX(AudioClip audioClip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(audioClip, position);
    }
}