using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointB : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Update()
    {


       

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
