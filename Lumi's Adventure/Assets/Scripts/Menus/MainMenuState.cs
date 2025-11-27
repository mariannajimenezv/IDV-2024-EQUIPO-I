using UnityEngine;

public class MainMenuState : IMenuState
{
    private readonly IMenu menu;

    public MainMenuState(IMenu menu)
    {
        this.menu = menu;
    }

    public void Enter()
    {
        GameObject panel = menu.GetPanel("MainMenu");
        if (panel != null) panel.SetActive(true);
    }

    public void Exit()
    {
        GameObject panel = menu.GetPanel("MainMenu");
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    public void Update()
    {

    }
}