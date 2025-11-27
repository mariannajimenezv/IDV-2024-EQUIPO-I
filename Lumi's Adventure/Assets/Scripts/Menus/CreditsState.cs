using UnityEngine;

public class CreditsState : IMenuState
{
    private readonly IMenu menu;

    public CreditsState(IMenu menu)
    {
        this.menu = menu;
    }

    public void Enter()
    {
        GameObject panel = menu.GetPanel("Credits");
        if (panel != null) panel.SetActive(true);
    }

    public void Exit()
    {
        GameObject panel = menu.GetPanel("Credits");
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