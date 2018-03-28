using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilling : Quest {

	// Use this for initialization
	void Start () {
        QuestName = "Kill Enemy";
        Description = "Kill 2 Skeletons for Ulrich";
        ExperienceReward = 100;
        Goals = new List<Goal>
        {
            new KillEnemyGoal(this,0, "Kill 2 Skeletons", false, 0, 2),
            new CollectionGoal(this,"ManaPotion","Pick up a mana potion", false,0,1),
            new CollectionGoal(this,"XP","Gain 10 XP points",false,0,1)
        };

        Goals.ForEach(g => g.Init());
	}

}
