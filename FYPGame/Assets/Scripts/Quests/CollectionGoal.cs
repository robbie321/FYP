using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public string ItemName { get; set; }

    public CollectionGoal(Quest quest,string ItemName, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemName = ItemName;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIManager.OnItemEquipped += ItemEquipped;
        Debug.Log("Item: "+CurrentAmount);
        Debug.Log(ItemName);
    }

    void ItemEquipped(Item item)
    {
        if (item.name == this.ItemName)
        {
            Debug.Log("Detected item pickup: " + ItemName);
            this.CurrentAmount++;
            Debug.Log(CurrentAmount);
            Evaluate();
        }
    }

}
