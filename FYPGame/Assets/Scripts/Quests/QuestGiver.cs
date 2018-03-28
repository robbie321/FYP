﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    [SerializeField]
    private GameObject quests;
    //string to quest giver to set quest
    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }
    public override void Interact()
    {
        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            Quest.CheckGoals();
            CheckQuest();
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue(new string[] { "Thanks for that stuff that one time." }, name);
        }
    }
    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        Debug.Log("Quest is: "+Quest.Completed);
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueManager.Instance.AddNewDialogue(new string[] { "Thanks for that! Here's your reward.", "More dialogue" }, name);
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue(new string[] { "You're still in the middle of helping me. Get back at it!" }, name);
        }
    }

}