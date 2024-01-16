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
    }

    void OnDisable()
    {
        foreach (var menu in menus)
            if (menu.MenuBase)
                menu.MenuBase.ExitMenu();
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