using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSpace : MonoBehaviour {
    public Transform target;
    public float speed;
    private bool arrived = false;
    void Update()
    {

            if (DialogueHolder.Instance.Talked)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
       
           

        
        
    }
}
