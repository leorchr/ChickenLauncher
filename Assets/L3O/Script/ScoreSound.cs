using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSound : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;

    private float volume;
    private float pitch;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Reset();
    }

    public void PlayClip(int index)
    {
        AudioClip clip = GetClip(index);
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetClip(int index)
    {
        pitch += 0.05f;
        volume += 0.05f;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        return audioClip[index];
    }

    public void Reset()
    {
        volume = 0.6f;
        pitch = 0.8f;
    }
}