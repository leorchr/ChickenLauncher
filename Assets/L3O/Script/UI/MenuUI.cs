using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject volume;

    private void Awake()
    {
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

}
