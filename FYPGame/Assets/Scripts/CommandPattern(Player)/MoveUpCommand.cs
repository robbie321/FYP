using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCommand : ICommand {
    public void Execute()
    {
        Player.Instance.MoveUp();
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
