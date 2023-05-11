using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigData
{
    public static ConfigData instance;
    public float volume;

    public void SaveConfig()
    {
        volume = MenuUI.instance.GetVolume();
    }
}
