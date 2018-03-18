using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand :ICommand {
    public void Execute()
    {
        Player.Instance.MoveLeft();
    }

    public void Execute(string name)
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        Player.Instance.Stop();
    }

}

