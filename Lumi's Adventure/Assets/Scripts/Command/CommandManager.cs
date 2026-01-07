using UnityEngine;
using System.Collections.Generic;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandBuffer = new Stack<ICommand>();

    public void AddCommand(ICommand command, bool isUndoable = true)
    {
        command.Execute();

        if (isUndoable)
        {
            commandBuffer.Push(command);

            if (commandBuffer.Count > 50)
            {
                commandBuffer.Clear();
            }
        }
    }

    public void UndoLastCommand()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand activeCommand = commandBuffer.Pop();
            activeCommand.Undo();
        }
    }
}
