using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour, IMenu
{
    private IMenuState currentState;

    private Dictionary<string, GameObject> panels;

    [Header("UI")]
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject Credits; 
    public GameObject Game; 
    
    public GameObject SettingsGame; 

    private void Awake()
    {      
        panels = new Dictionary<string, GameObject>
        {
            { "MainMenu", MainMenu },
            { "SettingsMenu", SettingsMenu },
            { "Credits", Credits },
            { "Game", Game }
        };

        // Apagar paneles y manener el del menú principal
        foreach(var panel in panels.Values)
        {
            if(panel != null) panel.SetActive(false);
        }

        SetState(new MainMenuState(this));
    }

    // IMenu
    public GameObject GetGameObject() => gameObject;

    public IMenuState GetState() => currentState;

    public GameObject GetPanel(string panelName)
    {
        if (!panels.TryGetValue(panelName, out GameObject panel))
        {
            return null;
        }
        return panel;
    }

    public void SetState(IMenuState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update() => currentState?.Update();

    // UI 
    public void OnPlay() => SetState(new GameState(this));
    public void OnSettings() => SetState(new SettingsMenuState(this));

    public void OnCredits() => SetState(new CreditsState(this));
    public void OnBack() => SetState(new MainMenuState(this));
    public void OnQuit() => Application.Quit();
}