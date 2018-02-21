using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {
    //handle objectives
    public ObjectiveObject[] objectives;
    //keep track of which objectives have been completed
    public bool[] objectiveCompleted;
	// Use this for initialization
	void Start () {
        objectiveCompleted = new bool[objectives.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
