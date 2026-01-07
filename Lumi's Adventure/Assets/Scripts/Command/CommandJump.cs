using UnityEngine;

public class CommandJump : ICommand
{
    private LumiController _lumi;

    public CommandJump(LumiController lumi)
    {
        _lumi = lumi;
    }

    public void Execute()
    {
        _lumi.Jump();
    }

    public void Undo()
    {
        // Deshacer un salto es complejo, por ahora lo dejamos vacío
    }

}
