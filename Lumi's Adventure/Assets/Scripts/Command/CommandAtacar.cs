using UnityEngine;

public class CommandAtacar : ICommand
{
    private LumiController _lumi;

    public CommandAtacar(LumiController lumi)
    {
        _lumi = lumi;
    }

    public void Execute()
    {
        _lumi.Attack();
    }

    public void Undo()
    {
        Debug.Log("Deshaciendo ataque (Lógica pendiente)");
    }
}
