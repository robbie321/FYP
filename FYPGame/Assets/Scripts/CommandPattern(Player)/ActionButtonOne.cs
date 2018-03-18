using UnityEngine;
using System.Collections;

public class ActionButtonOne : ICommand
{
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
