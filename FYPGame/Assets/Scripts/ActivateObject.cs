using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour {
    Transform t;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            t = gameObject.transform.GetChild(0);
            t.gameObject.SetActive(true);
        }
       
    }
}
