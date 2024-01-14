using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainMenuPanel;

    private void Start()
    {
        if (settingsPanel != null || mainMenuPanel != null)
            settingsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("UITest");
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
