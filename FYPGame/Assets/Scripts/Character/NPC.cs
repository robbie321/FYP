using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    private IState currentState;
    public virtual void ChangeState(IState newState)
    {
        Debug.Log("Changing State");
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

