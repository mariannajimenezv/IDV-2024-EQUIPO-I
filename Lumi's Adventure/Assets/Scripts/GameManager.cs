using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [Header("Configuracion del Nivel")]
    public int totalFragments = 10;
    public int currentFragments = 0;
    public GameObject exitDoor;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // inicio salida bloqueada
        if (exitDoor != null) exitDoor.SetActive(false);
    }

    public void CollectFragment()
    {
        currentFragments++;
        Debug.Log($"Fragmentos: {currentFragments}/{totalFragments}");

        if (currentFragments >= totalFragments)
        {
            UnlockExit();
        }
    }

    void UnlockExit()
    {
        Debug.Log("SALIDA DESBLOQUEADA!!");
        if (exitDoor != null) exitDoor.SetActive(true);
        // maybe sonidito de completar nivel 
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinLevel()
    {
        Debug.Log("NIVEL COMPLETADO!!");
        // siguiente nivel (en la entrega pone que con uno vale)
    }
}
