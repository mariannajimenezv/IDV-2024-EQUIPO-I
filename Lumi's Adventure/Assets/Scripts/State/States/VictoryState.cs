using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryState : AMenuState
{
    private readonly GameObject panel;

    // Contructor
    public VictoryState(IMenu menu): base(menu)
    {
        this.menu = menu; 
        panel = menu.GetPanel("VictoryState");
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

    public override void OnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}