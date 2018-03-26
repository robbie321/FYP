using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulrich : NPC {
    public Transform point2;
    protected override void Update()
    {
        
        if (DialogueHolder.Instance.Talked)
        {

            transform.position = new Vector3(point2.position.x, point2.position.y, point2.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
}
