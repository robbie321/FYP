using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : Singleton<ControlsManager>
{

    // A dictionary for all movement keybind
    public Dictionary<string, KeyCode> Keybinds { get; private set; }
    // A dictionary for all actionKeybinds
    public Dictionary<string, KeyCode> ActionBinds { get; private set; }
    // The name of the keybind we are trying to set or change
    public string bindName;
    // Use this for initialization
    void Start()
    {
        Keybinds = new Dictionary<string, KeyCode>();

        ActionBinds = new Dictionary<string, KeyCode>();

        //Generates the default keybinds
        BindKey("UP", KeyCode.W);
        BindKey("LEFT", KeyCode.A);
        BindKey("DOWN", KeyCode.S);
        BindKey("RIGHT", KeyCode.D);

        BindKey("ACT1", KeyCode.Alpha1);
        BindKey("ACT2", KeyCode.Alpha2);
        BindKey("ACT3", KeyCode.Alpha3);
        BindKey("ACT4", KeyCode.Alpha4);
        BindKey("ACT5", KeyCode.Alpha5);
    }

    // Binds a specific key
    public void BindKey(string key, KeyCode keyBind)
    {
        //Sets the default dictionary to the keybinds
        Dictionary<string, KeyCode> currentDictionary = Keybinds;

        if (key.Contains("ACT")) //If we are trying to bind an actionbutton, then we use the actionbinds dictionary instead
        {
            currentDictionary = ActionBinds;
        }
        if (!currentDictionary.ContainsKey(key))//Checks if the key is new
        {
            //If the key is new we add it
            currentDictionary.Add(key, keyBind);

            //We update the text on the button
            UIManager.Instance.UpdateKeyText(key, keyBind);
        }
        else if (currentDictionary.ContainsKey(key)) //If we already have the keybind, then we need to change it to the new bind
        {
            //Looks for the old keybind
            string myKey = currentDictionary.FirstOrDefault(x => x.Value == keyBind).Key;

            //Unassigns the old keybind
            currentDictionary[myKey] = KeyCode.None;
            UIManager.Instance.UpdateKeyText(key, KeyCode.None);
        }

        //Makes sure the new key is bound
        currentDictionary[key] = keyBind;
        UIManager.Instance.UpdateKeyText(key, keyBind);
        bindName = string.Empty;
    }

    public void KeyBindOnClick(string bindName)
    {
        this.bindName = bindName;

    }

    private void OnGUI()
    {
        if (bindName != string.Empty)//Checks if we are going to save a keybind
        {
            Event e = Event.current; //Listens for an event

            if (e.isKey) //If the event is a key, then we change the keybind
            {
                BindKey(bindName, e.keyCode);
            }
        }
    }

}
