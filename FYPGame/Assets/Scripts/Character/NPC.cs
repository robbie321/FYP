using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public Transform point2;
    public string[] dialogue;
    protected bool IsInterectacting = false;
    public int NPCID { get; set; }
    public string name;
    private IState currentState;
    public virtual void ChangeState(IState newState)
    {
        Debug.Log("Changing State");
    }
    public virtual void Interact()
    {

    }
    public virtual void DeSelect()
    {
        Debug.Log("Deslected");
    }

    public virtual Transform Select()
    {
        return hitBox;
    }
}

