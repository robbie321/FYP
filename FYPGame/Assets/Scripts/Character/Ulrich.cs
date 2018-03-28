using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulrich : Singleton<Ulrich{
    
    [SerializeField]
    Transform point;
    protected void Update()
    {
        if ()
        {
            transform.position = new Vector3(point.position.x, point.position.y, point.position.z);
        }
    }

}
