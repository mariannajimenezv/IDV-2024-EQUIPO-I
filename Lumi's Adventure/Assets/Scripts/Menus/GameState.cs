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
        // Aquí podrías iniciar el tiempo del juego, habilitar controles del jugador, etc.
        Time.timeScale = 1; 
    }

    public void Exit()
    {
        Debug.Log("Saliendo del Juego");
        GameObject panel = menu.GetPanel("GameHUD");
        if (panel != null) panel.SetActive(false);
        
        // Pausar juego al salir de este estado, por ejemplo
        Time.timeScale = 0;
    }

    public void Update()
    {
        // Lógica del juego o chequeo de pausa
    }
}