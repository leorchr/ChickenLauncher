using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance;

    public SaveData saveData;
    public ConfigData configData;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
        saveData = new SaveData();
        configData = new ConfigData();
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
        configData.SaveConfig();
        string json = JsonUtility.ToJson(configData);
        Debug.Log(json);
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
            LoadData.instance.LoadConfig();
        }
        else
        {
            Debug.Log("Mon script marche pas c'est  chiant");
            configData = new ConfigData();
        }
    }
}