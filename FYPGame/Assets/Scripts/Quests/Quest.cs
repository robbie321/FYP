using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : Singleton<Quest> {

    public List<Goal> Goals { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        //if anything in goals list is comleted or not
        //if nothing is false, all goals completed
        Completed = Goals.All(g => g.Completed);
        Debug.Log(Completed);
    }

    public void GiveReward()
    {
        Player.Instance.totalXP += ExperienceReward;
    }
}
