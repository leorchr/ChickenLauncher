using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public Vector3 playerPosition = new Vector3(0f, 2f, 0f);
    public int score;

    public void Save()
    {
        playerPosition = PlayerMovement.instance.transform.position;
    }
    public void Load()
    {
        
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (currentScene == "Playground")
        {
            PlayerMovement.instance.controller.enabled = false;
            PlayerMovement.instance.controller.transform.position = playerPosition;
            PlayerMovement.instance.controller.enabled = true;
        }
    }
}

[Serializable]
public class ConfigData
{

    [Range(0f,1f)] public float volume = 1f;

    public void Save()
    {
        volume = MenuUI.instance.GetVolume();
    }

    public void Load()
    {
        int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0)
        {
            MenuUI.instance.SetVolume(volume);
        }
        else if (currentScene == 1)
        {
            GlobalSound.instance.SetVolume(volume);
        }
    }
}