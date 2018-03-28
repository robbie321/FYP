using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

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

    public CanvasGroup Quests
    {
        get
        {
            return quests;
        }

        set
        {
            quests = value;
        }
    }

    [SerializeField]
    private ActionButtons[] actionButtons;
    [SerializeField]
    private CanvasGroup controls;
    [SerializeField]
    private CanvasGroup spells;
    [SerializeField]
    private CanvasGroup quests;
    //A reference to all the kibind buttons on the menu
    private GameObject[] keybindButtons;
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemEquipped;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        keybindButtons = GameObject.FindGameObjectsWithTag("Control");
       
    }
    // Use this for initialization
    void Start () {

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

    public static void ItemEquipped(Item item)
    {
        if (OnItemEquipped != null)
            OnItemEquipped(item);
    }


}
