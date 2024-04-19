using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioScript : MonoBehaviour
{
    public Button clickBtn;
    public Button errorBtn;
    public Button keyboardBtn;

    public SoundManager soundManager;


    private void Awake()
    {
        clickBtn.onClick.AddListener(Click);
        errorBtn.onClick.AddListener(Error);
        keyboardBtn.onClick.AddListener(Keyboard);
    }


    private void Click()
    {
        soundManager.PlayClickSound();
    }

    private void Error()
    {
        soundManager.PlayErrorSound();
    }

    private void Keyboard()
    {
        soundManager.PlayKeyboardSound();
    }
}
