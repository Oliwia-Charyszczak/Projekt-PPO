using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MenuBase
{
    public override void EnterMenu()
    {
        gameObject.SetActive(true);
    }

    public override void ExitMenu()
    {
        gameObject.SetActive(false);
    }
}
