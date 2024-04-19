using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioScript : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject audioObject;

    private void Awake()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }


    private void PlaySound()
    {
        Debug.Log("CLICK!!");
        audioSource.Play();
    }
}
