using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour {
    /*
 * Keyboard_input acts as the invoker in the command pattern
 * it 
 */
    private static KeyboardInput instance;

    public static KeyboardInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KeyboardInput>();
            }

            return instance;
        }
    }
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    //characterCommands is a list of set commands	 
    Dictionary<string, ICommand> characterCommands;
    Dictionary<string, ICommand> controlCommands;

    ICommand Command;// { get; set; }
    KeyCode key;
    public KeyboardInput()
    {
        characterCommands = new Dictionary<string, ICommand>();
        controlCommands = new Dictionary<string, ICommand>();
    }
    /*
	 * handle_input is called to determine button clicks and execute the corresponding command
	 * from the command set.
	 */
    public void HandleInput()
    {
        //characterCommands.TryGetValue("D",out Command);
        //direction = Vector2.zero  ;  KeyCode.W
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Button Pressed");
            ButtonPressed("W");
         
        }
        if (Input.GetKeyDown(KeyCode.D)) ButtonPressed("D");
        if (Input.GetKeyDown(KeyCode.A)) ButtonPressed("A");
        if (Input.GetKeyDown(KeyCode.S)) ButtonPressed("S");
        if (Input.GetKeyDown(KeyCode.Alpha1)) ButtonPressed("ACT1");
        if (Input.GetKeyDown(KeyCode.Alpha2)) ButtonPressed("ACT2");
        if (Input.GetKeyDown(KeyCode.Alpha3)) ButtonPressed("ACT3");
        if (Input.GetKeyDown(KeyCode.Alpha4)) ButtonPressed("ACT4");
        if (Input.GetKeyDown(KeyCode.Alpha5)) ButtonPressed("ACT5");
        if (Input.GetKeyDown(KeyCode.Escape)) ButtonPressed("Escape");
        else if (!Input.anyKey) UndoButtonPressed();
    }
    /*
	 * setCommand takes in String "button" which acts an identifier or key in the hashmap
	 * and command acts as the corresponding value in the hashmap to that string argument passed.
	 */
    public void SetCommand(string button, ICommand command)
    {
        if (button.Contains("ACT"))
        {
            controlCommands.Add(button, command);
           // UIManager.Instance.UpdateKeyText(key, keyBind);
        }
        else
            characterCommands.Add(button, command);
       // UIManager.Instance.UpdateKeyText(key, keyBind);
    }
   

    /*
	 * buttonPressed takes in a string argument, which is the key value in the hashmap
	 * it then takes this string value and executes the corresponding command stored in the hashmap.
	 */
    public void ButtonPressed(string button)
    {
        if (button.Contains("ACT"))
        {
            controlCommands.TryGetValue(button, out Command);
            Command.Execute(button);
        }
        else
        {
            characterCommands.TryGetValue(button, out Command);

            Command.Execute();
        }
           
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
