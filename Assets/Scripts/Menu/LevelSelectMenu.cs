using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MenuBase
{
    public override void EnterMenu()
    {
        gameObject.SetActive(true);
    }

    public override void ExitMenu()
    {
        gameObject.SetActive(false);
    }

    public void SelectLevel1()
    {
        SceneManager.LoadScene("Lv1");
    }
    public void SelectLevel2()
    {
        SceneManager.LoadScene("Lv2");
    }
    public void SelectLevel3()
    {
        SceneManager.LoadScene("Lv3");
    }
}
