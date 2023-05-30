using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public static MenuUI instance;

    [Space]
    [Header("Panels")]
    [Space]
    [SerializeField] private GameObject defaultPanel;
    [SerializeField] private GameObject settingsPanel;


    [Space]
    [Header("Other")]
    [Space]
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject volumeSlider;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
    }

    private void Start()
    {
        defaultPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        SaveAndLoad.instance.NewSave();
        SceneManager.LoadScene("Playground");
    }

    public void OpenSettings()
    {
        EventSystem.current.SetSelectedGameObject(volumeSlider);
        settingsPanel.SetActive(true);
        defaultPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        defaultPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(settings);
    }

    public float GetVolume()
    {
        return volumeSlider.GetComponent<Slider>().value;
    }

    public void SetVolume(float volume)
    {
        volumeSlider.GetComponent<Slider>().value = volume;
    }

}
