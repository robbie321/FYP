using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Character {
    public float moveSpeed;
    private Vector2 maxWalkPoint;
    private Vector2 minWalkPoint;
    public bool isMoving;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;
    public Collider2D walkZone;
    private bool hasWalkZone;
    private bool facingRight;
    [SerializeField]
    public bool canMove;
    private Dialogue dm;
	// Use this for initialization
	protected override void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        
        dm = FindObjectOfType<Dialogue>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        facingRight = true;
        ChooseDirection();

        canMove = true;
	}

    // Update is called once per frame
    protected override void Update () {
        getMovement();
        checkIfTalking();
      //  base.Update();
	}
    private void getMovement()
    {
        //direction = Vector2.zero;
        if (isMoving)
        {


            switch (walkDirection)
            {
                /*case 0:
                    rigidBody.velocity = new Vector2(0, moveSpeed);
                    break;*/
                case 0:
                   // direction = Vector2.right;
                    rigidBody.velocity = Vector2.right;
                    animator.SetFloat("speed", 1);
                    
                    break;
                /*case 2:
                    rigidBody.velocity = new Vector2(0, -moveSpeed);
                    break;*/
                case 1:
                    //direction = Vector2.left;
                    rigidBody.velocity = Vector2.left;
                    animator.SetFloat("speed", 1);
                    break;
            }
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                isMoving = false;
                waitCounter = waitTime;
            }
            
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rigidBody.velocity = Vector2.zero;
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
            isMoving = true;
            walkCounter = walkTime;
     
    }

    private void checkIfTalking()
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
            rigidBody.velocity = Vector2.zero;
            return; //stop moving
        }
    }
}
