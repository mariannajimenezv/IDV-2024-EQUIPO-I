using UnityEngine;

/// <summary>
/// Define los métodos del contexto (MenuManager)
/// </summary>
public interface IMenu
{
    // Getters y Setters
    public void SetState(IMenuState state);
    public IMenuState GetState();

    // Cada estado utiliza un panel (UI)
    public GameObject GetPanel(string panel);
}
