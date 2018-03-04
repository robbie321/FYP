using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{

    //need to set objective to be active
    private ObjectiveManager objectiveManager;
    //number of objective
    public int objectiveNumber;
    //start, end quest
    public bool startObjective, endObjective;

    // Use this for initialization
    void Start()
    {
        objectiveManager = FindObjectOfType<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Yes(collision));


    }

    public IEnumerator Yes(Collider2D collision)
    {
        //if we are a player and the objective is not completed
        if (collision.CompareTag("Player") && !objectiveManager.objectiveCompleted[objectiveNumber])
        {
            //get the object number of the objective manager and check if its active
            if (startObjective && !objectiveManager.objectives[objectiveNumber].gameObject.activeSelf)
            {
                objectiveManager.objectives[objectiveNumber].gameObject.SetActive(true);
                yield return new WaitForSeconds(3);
                objectiveManager.objectives[objectiveNumber].StartObjective();
            }
            //check if objective is active
            if (endObjective && objectiveManager.objectives[objectiveNumber].gameObject.activeSelf)
            {
                objectiveManager.objectives[objectiveNumber].EndObjective();
            }
        }
    }
}
