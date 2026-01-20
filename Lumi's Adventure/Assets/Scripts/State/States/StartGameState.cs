using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameState : AMenuState
{
    private readonly GameObject panel;
    private List<GameObject> frames;
    private int frameCount;

    // Constructor
    public StartGameState(IMenu menu) : base(menu)
    {
        this.menu = menu; 
        panel = menu.GetPanel("GameStartState");
    }

    // Propiedades y transiciones de estado
    public override void Enter()
    {
        if (panel != null) panel.SetActive(true);
        Debug.Log("Entering Start Game Menu");

        frames = panel.transform.Cast<Transform>()
            .Where(c => c.name.Contains("Frame"))
            .Select(c => c.gameObject).ToList();
        frameCount = 0; 
        frames?[frameCount].SetActive(true);    
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

    // ---- METODOS DE BOTONES UTILIZADOS EN EL START GAME MENU ----
    public override void OnStartGame()
    {
        if(frameCount < frames.Count() - 1)
        {
            frames[frameCount].SetActive(false);
            frameCount++;
            frames[frameCount].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
