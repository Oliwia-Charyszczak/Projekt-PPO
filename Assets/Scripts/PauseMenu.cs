using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    [SerializeField] private GameManager gameManager;
    public AudioSource musicSource;

    public static bool isGamePaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);

        if (isGamePaused)
        {
            Continue();
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;

        isGamePaused = true;
        //gameManager.PauseMusic();
        musicSource.Pause();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;

        isGamePaused = false;

        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        //gameManager.ResumeMusic();
        musicSource.UnPause();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
