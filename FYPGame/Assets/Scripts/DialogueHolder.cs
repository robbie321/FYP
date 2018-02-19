using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
    public string dialogue;
    //reference to dialogue
    private Dialogue dm;
    //string array to hold each text line
    public string[] dialogueLines;
	// Use this for initialization
	void Start () {
        dm = FindObjectOfType<Dialogue>();
    }
	
	// Update is called once per frame
	void Update () {
		
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
                //if able to find villager movement script of parent object
                if(transform.parent.GetComponent<Villager>() != null)
                {
                    transform.parent.GetComponent<Villager>().canMove = false;
                }
            }
        }
    }
}
