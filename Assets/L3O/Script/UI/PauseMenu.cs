using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    public static bool gameIsPaused;

    public GameObject pauseMenu;
    public GameObject save;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    private void Start()
    {
        gameIsPaused = false;
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(save);
        LookWithMouse.instance.LockAndUnlockMouse();

        Time.timeScale = 0;

        gameIsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1;
        LookWithMouse.instance.LockAndUnlockMouse();

        gameIsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMainMenu()
    {
        Resume();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
        SaveAndLoad.instance.SaveToFile();
        Debug.Log(SaveAndLoad.instance.saveData.playerPosition);
        Debug.Log(SaveAndLoad.instance.saveData.score);
    }
}