using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour {

    public GameObject dialogueBox;
    public Text dialogueText;
    public bool dialogueActive = true;
    //store lines of text in an array
    public string[] dialogueLines;
    public int currentLine;
    public int counter = 0;
    //counter for what line were on in game

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            
            //when player presses space, dialogue moves to next line
            currentLine++;
        }	
        if(currentLine == 3)
        {
            DialogueHolder.Instance.Talked = true;

        }
        if(currentLine>= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            dialogueActive = false;
            currentLine = 0;
            
        }
        if(currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];

        }
        //dialogueText.text = dialogueLines[currentLine];
	}

    public void showText(string dialogue)
    {
        //set text to be displayed when player in NPC area
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;

    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dialogueBox.SetActive(true);
    }
}
