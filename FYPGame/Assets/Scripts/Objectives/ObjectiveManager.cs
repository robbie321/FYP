using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {
    //handle objectives
    public ObjectiveObject[] objectives;
    //keep track of which objectives have been completed
    public bool[] objectiveCompleted;
    public Dialogue dialogueManager;
	// Use this for initialization
	void Start () {
        objectiveCompleted = new bool[objectives.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowObjectiveText(string objectiveText)
    {
        //set the dialogue holder to be the objectiveText
        dialogueManager.dialogueLines = new string[1];
        dialogueManager.dialogueLines[0] = objectiveText;

        dialogueManager.currentLine = 0;
        dialogueManager.ShowDialogue();
    }
}
