using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Menu startMenu;
    [SerializeField] Menu[] menus;

    MenuBase currentMenu;

    void Start()
    {
        foreach (var menu in menus)
        {
            if (menu != null && menu.MenuBase != null)
            {
                menu.MenuBase.ExitMenu();
            }
        }

        SwitchMenuByName(startMenu.MenuName);

        if (Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    MenuBase GetMenuByName(string menuName)
    {
        foreach (var menu in menus)
            if (menu.MenuName == menuName && menu.MenuBase)
                return menu.MenuBase;

        return null;
    }

    public void SwitchMenuByName(string menuName)
    {
        var nextMenu = GetMenuByName(menuName);
        if (nextMenu)
        {
            if (currentMenu) currentMenu.ExitMenu();
            currentMenu = nextMenu;
            currentMenu.EnterMenu();
        }
        else
        {
            Debug.LogError($"Menu {menuName} not found!");
        }
    }
}