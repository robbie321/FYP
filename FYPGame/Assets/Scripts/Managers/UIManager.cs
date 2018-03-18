using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

    public CanvasGroup Controls
    {
        get
        {
            return controls;
        }

        set
        {
            controls = value;
        }
    }

    public CanvasGroup Spells
    {
        get
        {
            return spells;
        }

        set
        {
            spells = value;
        }
    }

    //characterCommands is a list of set commands	 
    //Dictionary<string, ICommand> characterCommands;
    //Dictionary<string, ICommand> controlCommands;
    //ICommand Command;
    [SerializeField]
    private ActionButtons[] actionButtons;
    [SerializeField]
    private CanvasGroup controls;
    [SerializeField]
    private CanvasGroup spells;
    /// <summary>
    /// A reference to all the kibind buttons on the menu
    /// </summary>
    private GameObject[] keybindButtons;
    private void Awake()
    {
        //characterCommands = new Dictionary<string, ICommand>();
        //controlCommands = new Dictionary<string, ICommand>();
        keybindButtons = GameObject.FindGameObjectsWithTag("Control");
       
    }
    // Use this for initialization
    void Start () {
        //SetUseable(actionButtons[0], SpellBook.MyInstance.GetSpell("Lightning"));
        //SetUseable(actionButtons[1], SpellBook.MyInstance.GetSpell("Fire"));
        //SetUseable(actionButtons[2], SpellBook.MyInstance.GetSpell("Ice Blast"));

    }
	
	// Update is called once per frame
	void Update () {
     

    }


    public void OpenClose(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }


    // Updates the text on a keybindbutton after the key has been changed
    public void UpdateKeyText(string key, KeyCode code)
    {
        Text tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<Text>();
        tmp.text = code.ToString();
    }

    public void ClickActionButton(string name)
    {
        Array.Find(actionButtons, x => x.gameObject.name == name).Button.onClick.Invoke();
    }



}
