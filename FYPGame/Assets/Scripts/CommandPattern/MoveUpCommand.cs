using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCommand : ICommand {
    /*
	 * @param player: Acts as the reciever to this concrete command
	 */
    Character player;
    /*
	 * MoveUpCommand takes in a character reference to act as the receiver
	 */
    public MoveUpCommand(Character character)
    {
        player = character;
    }
    /*
	 * execute calls the character method to be executed 
	 */
    public void Execute()
    {
        player.MoveUp();
    }

}
