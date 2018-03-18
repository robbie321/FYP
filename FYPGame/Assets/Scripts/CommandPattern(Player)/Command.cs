using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple command interface with execute and undo operations
 */
public interface ICommand{

    void Execute();
    void Execute(string name);
    void Undo();

}
