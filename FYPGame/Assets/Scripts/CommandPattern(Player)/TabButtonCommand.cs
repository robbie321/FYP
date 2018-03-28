using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButtonCommand : ICommand {
    public void Execute()
    {
        UIManager.Instance.OpenClose(UIManager.Instance.Quests);
    }

    public void Execute(string name)
    {

    }

    public void Undo()
    {

    }


}
