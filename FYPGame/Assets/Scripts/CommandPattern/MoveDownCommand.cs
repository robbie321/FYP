using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : ICommand {


    /*
	 * @param player: Acts as the reciever to this concrete command
	 */
    Character player;
    /*
	 * MoveDownCommand takes in a character reference to act as the receiver
	 */
    public MoveDownCommand(Character player)
    {
        this.player = player;
    }
    /*
	 * execute calls the character method to be executed 
	 */
    public void Execute()
    {
        player.MoveDown();
    }

    public void Undo()
    {
        player.Stop();
    }
}
