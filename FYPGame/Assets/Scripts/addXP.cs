using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addXP : MonoBehaviour {

    [SerializeField]
    private int value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            XPUp(collision);
        }
    }

    void XPUp(Collider2D player)
    {
        Player.Instance.XP.PlayerCurrentValue += value;
        Player.Instance.totalXP += value;
        //remove object
        Destroy(gameObject);
    }
}
