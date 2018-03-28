using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : Singleton<DialogueHolder>
{

    public bool Talked
    {
        get
        {
            return talked;
        }

        set
        {
            talked = value;
        }
    }

    public string dialogue;
    //reference to dialogue
    private Dialogue dm;
    //string array to hold each text line
    public string[] dialogueLines;
    [SerializeField]
    private bool talked = false;
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        dm = FindObjectOfType<Dialogue>();
    }
	
	// Update is called once per frame
	void Update () {
        IsActive();
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //dm.showText(dialogue);
                //check if dialogue box is active
                if (!dm.dialogueActive)
                {
                    //dialogue manager array is = to this array
                    dm.dialogueLines = dialogueLines;
                    dm.currentLine = 0;
                    dm.ShowDialogue();

                }
                if(dm.counter == dialogueLines.Length-1)
                {
                    talked = true;
                }
                //if able to find villager movement script of parent object
                if(transform.parent.GetComponent<NPC>() != null)
                {
                    //transform.parent.GetComponent<NPC>().canMove = false;
                }
            }
        }
    }

    void IsActive()
    {
        if (Talked && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
            gameObject.SetActive(true);
    }
}
