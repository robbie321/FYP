using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput {
    /*
 * Keyboard_input acts as the invoker in the command pattern
 * it 
 */
    
	  //characterCommands is a list of set commands	 
    Dictionary<string, ICommand> characterCommands;
    
    ICommand Command;// { get; set; }
    public KeyboardInput()
    {
        characterCommands = new Dictionary<string, ICommand>();
    }
    /*
	 * handle_input is called to determine button clicks and execute the corresponding command
	 * from the command set.
	 */
    public void HandleInput()
    {
        //characterCommands.TryGetValue("D",out Command);
        //direction = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Button Pressed");
            ButtonPressed("W");
         
        }
        if (Input.GetKeyDown(KeyCode.D)) ButtonPressed("D");
        if (Input.GetKeyDown(KeyCode.A)) ButtonPressed("A");
        if (Input.GetKeyDown(KeyCode.S)) ButtonPressed("S");
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonPressed("Escape");
        else if (!Input.anyKey) UndoButtonPressed();
        //if (Input.GetKey(KeyCode.W)) this.buttonPressed("one");
    }
    /*
	 * setCommand takes in String "button" which acts an identifier or key in the hashmap
	 * and command acts as the corresponding value in the hashmap to that string argument passed.
	 */
    public void SetCommand(string button, ICommand command)
    {
        characterCommands.Add(button, command);
    }

    /*
	 * buttonPressed takes in a string argument, which is the key value in the hashmap
	 * it then takes this string value and executes the corresponding command stored in the hashmap.
	 */
    public void ButtonPressed(string button)
    {

          characterCommands.TryGetValue(button, out Command);
          Command.Execute();
        
    }

    public void UndoButtonPressed()
    {
        if(Command == null)
        {
            Debug.Log("Command not set");
        }
        else
        {
            Command.Undo();
        }
        
    }
}
