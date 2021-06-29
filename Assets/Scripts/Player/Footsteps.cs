using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.pitch = UnityEngine.Random.Range(0.7f, 1.3f);
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0 , clips.Length)];
    }
}
