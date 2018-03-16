using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    /*
	 * @param player: Acts as the reciever to this concrete command
	 */
    Character player;
    /*
	 * MoveRightCommand takes in a character reference to act as the receiver
	 */
    public MoveRightCommand(Character player)
    {
        this.player = player;
    }
    /*
	 * execute calls the character method to be executed 
	 */
    public void Execute()
    {
        player.MoveRight();
    }

    public void Undo()
    {
        player.Stop();
    }
}

