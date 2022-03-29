using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mainSound;
    public AudioClip escapeSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mainSound;
        audioSource.Play();
    }
}
