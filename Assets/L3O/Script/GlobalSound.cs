using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GlobalSound : MonoBehaviour
{
    public static GlobalSound instance;

    public AudioMixer audioMixer;
    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
