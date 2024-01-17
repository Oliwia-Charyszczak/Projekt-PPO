using UnityEngine;

[System.Serializable]
class Menu
{
    [SerializeField] string menuName;
    [SerializeField] MenuBase menuBase;

    public string MenuName => menuName;
    public MenuBase MenuBase => menuBase;
}
