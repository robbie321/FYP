using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Player and enemies to inherit from this script
 * add funtionality to player and enemies
 * abstract as a character cannot exist on its own but players abd enemies can
 */
public abstract class Character : MonoBehaviour {
    // encapsulate speed
    [SerializeField]
    private float speed;
    private float moveVelocity;
   //Player can access direction
    protected Vector2 direction;
    //Players Animator
    protected Animator animator;
   
    public Rigidbody2D rigidBody;
    //villager can move when not in dialogue
    
    // Use this for initialization
    protected virtual void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
    //Virtual means we can overide Update from Player.cs
	protected virtual void Update () {
        Move();
	}

    public void Move()
    {
        //moveVelocity = speed * Input.GetAxisRaw("Horizontal");
        //change transform to move the character
        //Time.deltatime time that has passed since last update(same speed for all computers)FPS not dependant on CPU cycles
        transform.Translate(direction * speed * Time.deltaTime);

        if(direction.x != 0 || direction.y != 0){
            AnimateMovement(direction);
        }

        else
        {
            animator.SetLayerWeight(1, 0);
        }
        
    }

    //change animation based on direction
    public void AnimateMovement(Vector2 direction)
    {
        //set Layer weight of Walk Layer to 1 to show walk movement
        animator.SetLayerWeight(1, 1);
        //access players Animator
        animator.SetFloat("x", direction.x);

        animator.SetFloat("y", direction.y);


    }
}
