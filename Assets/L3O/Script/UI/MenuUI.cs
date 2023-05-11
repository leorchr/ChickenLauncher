using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public static MenuUI instance;

    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject volume;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
        settings.SetActive(false);
    }

    public void Load()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        EventSystem.current.SetSelectedGameObject(volume);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void VolumeUpdate()
    {
        SaveAndLoad.instance.SaveConfigFile();
    }

    public float GetVolume()
    {
        return volume.GetComponent<Slider>().value;
    }

}
