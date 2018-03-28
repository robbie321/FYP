using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class QuestDisplayUI : MonoBehaviour {
    [SerializeField]
    Text[] goalsText;
    public GameObject QuestPanel;
    bool looped = true;
    int number=1;
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
                    goalsText[i].text = number+". " + Quest.Instance.Goals[i].Description;
                    number++;
                }
                looped = false;
            }
            for (int i = 0; i < Quest.Instance.Goals.Count; i++)
            {
                if (Quest.Instance.Goals[i].Completed)
                    goalsText[i].color = Color.green;
            }

        }
        catch (Exception e)
        {

        }

    }

    public void Pressed()
    {
       

        
    }
}
