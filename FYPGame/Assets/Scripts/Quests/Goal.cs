using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Quest can have multiple Goals
public class Goal : Singleton<Goal> {
    public Quest Quest { get; set; }
    public string Description { get; set; }
    //if goal completed
    public bool Completed { get; set; }
    //amount we have done
    public int CurrentAmount { get; set; }
    //amount we need done
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {
        // default init stuff
    }

    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        this.Quest.CheckGoals();
        Completed = true;
        Debug.Log("Goal marked as completed.");
    }
}
