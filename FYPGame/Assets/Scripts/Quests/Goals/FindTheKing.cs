using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheKing : Quest {

    void Start()
    {
        QuestName = "Find The King";
        Description = "Must find the king and stop him before it's too late";
        ExperienceReward = 10000;
        Goals = new List<Goal>
        {
            new KillEnemyGoal(this,0, "Kill 2 Skeletons", false, 0, 2),
            new CollectionGoal(this,"ManaPotion","Pick up a mana potion", false,0,1),
            new CollectionGoal(this,"XP","Gain 10 XP points",false,0,1)
        };

        Goals.ForEach(g => g.Init());
    }

    private void Update()
    {
        if (Completed)
        {
            Destroy(this);
        }
    }
}
