using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(int index)
    {
        AudioClip clip = GetClip(index);
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetClip(int index)
    {
        audioSource.volume = Random.Range(0.6f, 0.8f);
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        return audioClip[index];
    }
}
