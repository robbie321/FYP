using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPItem : Item {
    public override void Use()
    {
        Player.Instance.XP.PlayerCurrentValue += value;
        Destroy(gameObject);
    }

}
