using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item{
    public override void Use()
    {
       if(Player.Instance.shield.PlayerCurrentValue < Player.Instance.shield.MaxValue)
        {
            Player.Instance.shield.PlayerCurrentValue += value;

        }
        Destroy(gameObject);
    }
}
