using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInterfaceAudio : MonoBehaviour
{
    public static UseInterfaceAudio instance { private set; get; }
    private AudioSource audioSource;
    public AudioClip card;
    public AudioClip openBox;
    public AudioClip glass;
    public AudioClip clock;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
