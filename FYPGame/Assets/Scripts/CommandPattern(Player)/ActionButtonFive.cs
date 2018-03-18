using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonFive : ICommand {

    public void Execute()
    {

    }

    public void Execute(string name)
    {
        UIManager.Instance.ClickActionButton(name);
    }

    public void Undo()
    {
    }
}
