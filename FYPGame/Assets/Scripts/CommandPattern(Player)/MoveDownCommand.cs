using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : ICommand {

    /*
	 * execute calls the character method to be executed 
	 */
    public void Execute()
    {
        Player.Instance.MoveDown();
    }

    public void Execute(string name)
    {
        throw new NotImplementedException();
    }

    public void Undo()
    {
        Player.Instance.Stop();
    }
}
