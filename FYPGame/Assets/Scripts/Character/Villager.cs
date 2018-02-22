using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Character {
   // public float moveSpeed;
    private Vector2 maxWalkPoint;
    private Vector2 minWalkPoint;
    public bool moving;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    //0,1 0 to go right, 1 to go left
    private int walkDirection;
    public Collider2D walkZone;
    private bool hasWalkZone;
    //check if player is facing right
    private bool facingRight;
    [SerializeField]
    public bool canMove;
    private Dialogue dm;
	// Use this for initialization
	protected override void Start () {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        dm = FindObjectOfType<Dialogue>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        facingRight = true;
        ChooseDirection();

        canMove = true;
	}

    // Update is called once per frame
    protected override void Update () {
        GetMovement();
        CheckIfTalking();
      //  base.Update();
	}
    private void GetMovement()
    {
        direction = Vector2.zero;
        if (moving)
        {


            switch (walkDirection)
            {
                /*case 0:
                    rigidBody.velocity = new Vector2(0, moveSpeed);
                    break;*/
                case 0:
                    direction = Vector2.right;     
                    animator.SetFloat("speed", 1);
                    
                    break;
                /*case 2:
                    rigidBody.velocity = new Vector2(0, -moveSpeed);
                    break;*/
                case 1:
                    direction = Vector2.left;
                    animator.SetFloat("speed", 1);
                    break;
            }
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                moving = false;
                waitCounter = waitTime;
            }
            
        }
        else
        {
            waitCounter -= Time.deltaTime;
            direction += Vector2.zero;
            animator.SetFloat("speed", 0);
            // direction = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
      
           walkDirection = Random.Range(0, 2);
        //flip the scale of the villager when he is not facing in the right position
        if(walkDirection == 0 && !facingRight || walkDirection == 1 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
            moving = true;
            walkCounter = walkTime;
     
    }

    private void CheckIfTalking()
    {
        //no dialogue, sprite can move around the world
        if (!dm.dialogueActive)
        {
            canMove = true;
        }
        //check
        if (!canMove)
        {
            //direction = Vector2.zero;
            direction = Vector2.zero;
            return; //stop moving
        }
    }
}
