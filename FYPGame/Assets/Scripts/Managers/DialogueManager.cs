using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : Singleton<DialogueManager>
{
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();
    public bool Talked;
    //reference to continue button
    Button continueButton;
    //reference to both dialogue text and name of who were talking to
    Text dialogueText, nameText;
    int dialogueIndex;
    private void Awake()
    {
        continueButton = dialoguePanel.GetComponentInChildren<Button>();
        dialogueText = dialoguePanel.transform.GetChild(1).GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponentInChildren<Text>();
        //add event listener for continue
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        //empty list with no elements
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        //Debug.Log(dialogueLines.Count);
        this.npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            Talked = true;
            dialoguePanel.SetActive(false);
        }

    }
}
