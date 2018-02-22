using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private float speed;

    private Transform target;
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //targets position - the fireballs position
        Vector2 direction = target.position - transform.position;
        myRigidbody.velocity = direction.normalized * speed;
        //change rotation of fireball
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //set it
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
