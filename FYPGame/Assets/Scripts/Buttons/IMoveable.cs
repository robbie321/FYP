using UnityEngine;
using System.Collections;

public interface IMoveable
{
    //everything that can be moved must have an icon
    Sprite Icon
    {
        get;
    }
}
