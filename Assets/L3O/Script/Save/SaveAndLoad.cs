using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance;

    [HideInInspector] public SaveData saveData;
    [HideInInspector] public ConfigData configData;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
    }

    private void Start()
    {
        LoadConfigFile();
    }

    public void SaveToFile()
    {
        saveData.Save();
        string json = JsonUtility.ToJson(saveData);
        Debug.Log(json);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }

    public void NewSave()
    {
        saveData = new SaveData();
        string json = JsonUtility.ToJson(saveData);
        Debug.Log(json);
        File.Create(Application.persistentDataPath + "/data.save").Dispose();
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }


    public void LoadFile()
    {
        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            saveData = JsonUtility.FromJson<SaveData>(json);
            saveData.Load();
        }
        else
        {
            saveData = new SaveData();
        }
    }

    public void SaveConfigFile()
    {
        configData.Save();
        string json = JsonUtility.ToJson(configData);
        if (!File.Exists(Application.persistentDataPath + "/config.save"))
        {
            File.Create(Application.persistentDataPath + "/config.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/config.save", json);
    }

    public void LoadConfigFile()
    {
        if (File.Exists(Application.persistentDataPath + "/config.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/config.save");
            configData = JsonUtility.FromJson<ConfigData>(json);
            configData.Load();
        }
        else
        {
            Debug.Log("First Time Running the game");
            configData = new ConfigData();
        }
    }
}