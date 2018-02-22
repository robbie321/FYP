using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveObject : MonoBehaviour {
    //
    public int objectiveNumber;
    public ObjectiveManager objectiveManager;
    public string startText, endText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartObjective()
    {
        objectiveManager.ShowObjectiveText(startText);
    }

    public void EndObjective()
    {
        objectiveManager.ShowObjectiveText(endText);
        objectiveManager.objectiveCompleted[objectiveNumber] = true;
        //objective should be deactivated
        gameObject.SetActive(false);
        //tell objective manager that objective is now completed
    }
}
