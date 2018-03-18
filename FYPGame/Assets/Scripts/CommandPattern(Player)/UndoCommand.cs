using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoCommand : ICommand
{
    Character player;

    public UndoCommand(Character player)
    {
        this.player = player;
    }
    public void Execute()
    {
        
    }

    public void Execute(string name)
    {
        throw new NotImplementedException();
    }

    public void Undo()
    {
        player.Stop();
    }
}
