using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMana : MonoBehaviour {
   // public GameObject effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ManaUp(collision);
        }
    }

    void ManaUp(Collider2D player)
    {
        //spawn effect
        // Instantiate(effect, transform.position, transform.rotation);
        //apply effect to player
        Player mana = player.GetComponent<Player>();
        mana.shield.PlayerCurrentValue += 10;
        //remove object
        Destroy(gameObject);
        Debug.Log("Mana + 10");
    }
}
