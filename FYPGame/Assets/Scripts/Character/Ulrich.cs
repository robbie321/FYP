using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulrich : NPC {
   // public string[] dialogue, dialogue2, dialogue3;
    protected override void Update()
    {  
        if (DialogueManager.Instance.Talked)
        {

            transform.position = new Vector3(point2.position.x, point2.position.y, point2.position.z);
        }
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
            
        //gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

}
