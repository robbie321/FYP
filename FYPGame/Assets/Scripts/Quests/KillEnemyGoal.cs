using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyGoal : Goal
{
    public int EnemyID { get; set; }

    public KillEnemyGoal(Quest quest,
        int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.EnemyID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDied;
        Debug.Log(CurrentAmount);
        Debug.Log(EnemyID);
    }

    void EnemyDied(Enemy enemy)
    {
        Debug.Log(enemy.NPCID);
        if (enemy.NPCID == this.EnemyID)
        {
            Debug.Log("Detected enemy death: " + EnemyID);
            this.CurrentAmount++;
            Debug.Log(CurrentAmount);
            Evaluate();
        }
    }

}
