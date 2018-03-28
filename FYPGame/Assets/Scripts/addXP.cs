using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour, IItem {

    [SerializeField]
    private int value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Use();
        }
    }
    public void Use()
    {
        Player.Instance.XP.PlayerCurrentValue += value;
        Destroy(gameObject);
    }

}
