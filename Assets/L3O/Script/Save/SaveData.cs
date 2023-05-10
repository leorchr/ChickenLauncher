using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public static SaveData instance;

    public string text = "bonjour";
    public Vector3 playerPosition = Vector3.zero;


    public void Save()
    {
        text = "save";
        playerPosition = PlayerMovement.instance.transform.position;
    }

    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerMovement.instance.controller.Move(playerPosition);
        PauseMenu.Instance.Resume();
        Debug.Log("Heeeeeeeeey salut a tous et a toutes les amisssssssssssss, c'est David Lafarge Pokemon");
    }
}
