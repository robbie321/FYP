using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    [SerializeField]
    Transform point;
    public string[] dialogue;
    protected bool IsInterectacting = false;
    public int NPCID { get; set; }
    public string name;
    public bool talked;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
        if (collision.CompareTag("Trigger") && !IsInterectacting)
        {
            IsInterectacting = true;
            Debug.Log("Entered");
            DialogueManager.Instance.AddNewDialogue(dialogue, name);
        }
    }

    //protected override void Update()
    //{
    //    if(DialogueManager.Instance.Talked && name == "Ulrich")
    //    {
    //        transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
    //    }
    //} 
}

