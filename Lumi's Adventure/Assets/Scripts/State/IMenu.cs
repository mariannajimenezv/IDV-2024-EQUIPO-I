using UnityEngine;

public interface IMenu
{
    // Getters y Setters
    public void SetState(IState state);
    public IState GetState();

    public GameObject GetPanel(string panel);
}
