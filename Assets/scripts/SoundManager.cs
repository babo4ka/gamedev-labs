using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour, ISoundManager 
{

    private AudioSource _audioSource;

    public SoundParameters soundParameters;


    void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    public void PlayClickSound()
    {
        _audioSource.clip = soundParameters.clickClip;
        _audioSource.Play();
    }

    public void PlayErrorSound()
    {
        _audioSource.clip = soundParameters.errorClickClip;
        _audioSource.Play();
    }

    public void PlayKeyboardSound()
    {
        _audioSource.clip = soundParameters.keyboardSoundClip;
        _audioSource.Play();
    }
}
