using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : AMenuState
{
    private readonly GameObject panel;

    // Constructor
    public GameOverState(IMenu menu): base(menu)
    {
        this.menu = menu; 
        panel = menu.GetPanel("GameOverState");
    }

    // Propiedades y transiciones de estado
    public override void Enter()
    {
        if (panel != null) panel.SetActive(true);
        Time.timeScale = 0; 
    }

    public override void Exit()
    {
        // La maquina de estados "muere" aqui, por lo que no es necesario hacer nada
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        
    }

    // ---- METODOS DE BOTONES UTILIZADOS EN EL MENU GAME OVER ----
    public override void OnBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public override void OnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}