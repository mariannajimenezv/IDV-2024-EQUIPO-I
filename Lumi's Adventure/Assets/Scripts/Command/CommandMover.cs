using UnityEngine;

public class CommandMover : ICommand
{
    private LumiController _lumi;
    private Vector3 _direction;

    // Constructor: Recibe quién se mueve y hacia dónde
    public CommandMover(LumiController lumi, Vector3 direction)
    {
        _lumi = lumi;
        _direction = direction;
    }

    public void Execute()
    {
        _lumi.Move(_direction);
    }

    public void Undo()
    {
        // Moverse en la dirección opuesta
        _lumi.Move(-_direction);
    }
}
