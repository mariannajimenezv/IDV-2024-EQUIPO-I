using UnityEngine;

public class SettingsMenuState : IMenuState
{
    private readonly IMenu menu;

    public SettingsMenuState(IMenu menu)
    {
        this.menu = menu;
    }

    public void Enter()
    {
        GameObject panel = menu.GetPanel("SettingsMenu");
        if (panel != null) panel.SetActive(true);
    }

    public void Exit()
    {
        GameObject panel = menu.GetPanel("SettingsMenu");
        if (panel != null) panel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
}