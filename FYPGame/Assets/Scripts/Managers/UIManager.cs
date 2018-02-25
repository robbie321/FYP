﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private Button[] actionButtons;
    private KeyCode action1, action2, action3;
	// Use this for initialization
	void Start () {
        action1 = KeyCode.Alpha1;
        action2 = KeyCode.Alpha2;
        action3 = KeyCode.Alpha3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(action1))
        {
            OnActionButtonPressed(0);
        }
        if (Input.GetKeyDown(action2))
        {
            OnActionButtonPressed(1);
        }
        if (Input.GetKeyDown(action3))
        {
            OnActionButtonPressed(2);
        }
	}

    private void OnActionButtonPressed(int index)
    {
        actionButtons[index].onClick.Invoke();
    }
}