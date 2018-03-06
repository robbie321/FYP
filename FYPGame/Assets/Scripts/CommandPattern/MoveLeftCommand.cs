using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand :ICommand {

    /*
	 * @param player: Acts as the reciever to this concrete command
	 */
    Character player;
    /*
	 * MoveLeftCommand takes in a character reference to act as the receiver
	 */
   public MoveLeftCommand(Character player)
    {
        this.player = player;
    }
   /*
    * execute calls the character method to be executed 
    */
    public void Execute()
    {
        player.MoveLeft();
    }

}

