using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    /*
	 * execute calls the character method to be executed 
	 */
    public void Execute()
    {
        Player.Instance.MoveRight();
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

