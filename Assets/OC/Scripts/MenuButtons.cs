using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectPanel;

    private void Start()
    {
        if (settingsPanel != null || mainMenuPanel != null)
            settingsPanel.SetActive(false);
            levelSelectPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Lv 1");
    }

    public void LevelTwo()
    {

    }

    public void LevelThree()
    {

    }

    public void OpenLevelSelection()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
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

    public void CloseLevelSelection()
    {
        levelSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
