using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName = "Edu/Create SoundParameters")]
public class SoundParameters : ScriptableObject
{
    public AudioClip clickClip;
    public AudioClip errorClickClip;
    public AudioClip keyboardSoundClip;
}
