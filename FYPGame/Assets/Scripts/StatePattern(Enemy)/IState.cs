using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Defines functions for enemy
public interface IState  {
    //Prepare the state
    void Enter(Enemy parent);

    void Update();

    void Exit();
}
