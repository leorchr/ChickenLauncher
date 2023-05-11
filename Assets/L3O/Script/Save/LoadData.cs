using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class LoadData : MonoBehaviour
{
    public static LoadData instance;

    public AudioMixer masterMixer;

    public void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
        LoadConfig();
    }
    public void LoadConfig()
    {
        masterMixer.SetFloat("musicVol", Mathf.Log10(SaveAndLoad.instance.configData.volume) * 20);
        Debug.Log("Volume Set up to : " + SaveAndLoad.instance.configData.volume);
    }
}
