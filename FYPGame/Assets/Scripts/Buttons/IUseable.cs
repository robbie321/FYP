using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Use we need to use a spell or potion etc. anything that can be clicked
public interface IUseable {
    //all items need an icon
    Sprite Icon
    {
        get;
    }

    void Use();
}
