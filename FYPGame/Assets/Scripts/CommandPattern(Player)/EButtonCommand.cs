using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EButtonCommand : ICommand {

    public void Execute()
    {
        UIManager.Instance.OpenClose(UIManager.Instance.Spells);
    }

    public void Execute(string name)
    {
    }

    public void Undo()
    {

    }
}
