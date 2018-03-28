using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class QuestDisplayUI : MonoBehaviour {
    [SerializeField]
    Text[] dialogueText;
    public GameObject QuestPanel;
    bool looped = true;
    public void Start()
    {
    }
    void Update()
    {
        try
        {
            while (looped)
            {
                for (int i = 0; i < Quest.Instance.Goals.Count; i++)
                {
                    dialogueText[i].text = Quest.Instance.Goals[i].Description;
                }
                looped = false;
            }
            for (int i = 0; i < Quest.Instance.Goals.Count; i++)
            {
                if (Quest.Instance.Goals[i].Completed)
                    dialogueText[i].color = Color.green;
            }

        }
        catch(Exception e)
        {

        }
        
        
    }
}
