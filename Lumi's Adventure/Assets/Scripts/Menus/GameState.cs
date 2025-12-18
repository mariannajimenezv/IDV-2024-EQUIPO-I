using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : IMenuState
{
    private readonly IMenu menu;

    public GameState(IMenu menu)
    {
        this.menu = menu;
    }

    public void Enter()
    {
        Debug.Log("Entrando al Juego (HUD)");
        GameObject panel = menu.GetPanel("GameHUD");
        if (panel != null) panel.SetActive(true);
        
        SceneManager.LoadScene("Game");
 
        Time.timeScale = 1; 
    }

    public void Exit()
    {
        Debug.Log("Saliendo del Juego");
        GameObject panel = menu.GetPanel("GameHUD");
        if (panel != null) panel.SetActive(false);
        

        Time.timeScale = 0;
    }

    public void Update()
    {
        // Lógica del juego o chequeo de pausa
    }
}