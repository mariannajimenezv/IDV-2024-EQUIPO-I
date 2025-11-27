/// <summary>
/// Define las acciones soportadas por los menús. 
/// Cada menú representa un estado.
/// </summary>
public interface IMenuState
{
    public void Enter();
    public void Exit();
    public void Update();
}
