using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an abstract class that all characters needs to inherit from
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    //The Player's movement speed
    [SerializeField]
    private float speed;
    // A reference to the character's animator
    private Animator animator;
    //The Player's direction
    private Vector2 direction;
    //The Character's rigidbody
    protected Rigidbody2D myRigidbody;
    // indicates if the character is attacking or not
    private bool isAttacking = false;
    protected bool isDead = false;
    // A reference to the attack coroutine
    protected Coroutine attackRoutine;
    //character hitBox for selecting
    [SerializeField]
    protected Transform hitBox;
    //exit points for spells
    [SerializeField]
    private Transform[] exitPoints;
    // The player's initialHealth
    [SerializeField]
    private float initHealth;
    [SerializeField]
    protected StatBar health;
    //index to keep track of what exit point to use, 0 is defaulted as down
    private int exitIndex = 0;
    private Transform target;
    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    // Indicates if character is moving or not
    public bool IsMoving
    {
        get
        {
            return Direction.x != 0 || Direction.y != 0;
        }
    }

    public Vector2 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }

        set
        {
            isAttacking = value;
        }
    }

    public Animator Animator
    {
        get
        {
            return animator;
        }

        set
        {
            animator = value;
        }
    }

    public Transform[] ExitPoints
    {
        get
        {
            return exitPoints;
        }

        set
        {
            exitPoints = value;
        }
    }

    public int ExitIndex
    {
        get
        {
            return exitIndex;
        }

        set
        {
            exitIndex = value;
        }
    }

    protected virtual void Start()
    {
        //Makes a reference to the rigidbody2D
        myRigidbody = GetComponent<Rigidbody2D>();

        //Makes a reference to the character's animator
        Animator = GetComponent<Animator>();

        //Initialise characters health
        health.Initialize(initHealth, initHealth);
    }

    // Update is marked as virtual, so that we can override it in the subclasses
    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        
        Move();
    }
    // Moves the player
    public void Move()
    {
        if (!isDead)
        {
            //Makes sure that the player moves
            myRigidbody.velocity = Direction.normalized * Speed;
        }
       
    }
    //Makes sure that the right animation layer is playing
    public void HandleLayers()
    {
        //Checks if we are moving or standing still, if we are moving then we need to play the move animation
        if (IsMoving)
        {
            ActivateLayer("Walk Layer");

            //Sets the animation parameter so that he faces the correct direction
            Animator.SetFloat("x", Direction.x);
            Animator.SetFloat("y", Direction.y);

            //StopAttack();
        }
        else if (IsAttacking)
        {
            ActivateLayer("Attack Layer");
        }
        else if (isDead)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            ActivateLayer("Die Layer");

        }
        else
        {
            //Makes sure that we will go back to idle when we aren't pressing any keys.
            ActivateLayer("Idle Layer");
        }
    }
    // Activates an animation layer based on a string
    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < Animator.layerCount; i++)
        {
            Animator.SetLayerWeight(i, 0);
        }

        Animator.SetLayerWeight(Animator.GetLayerIndex(layerName), 1);
    }

    public virtual void TakeDamage(float damage, Transform source)
    {
        //reduce health
        health.PlayerCurrentValue -= damage;
        if (health.PlayerCurrentValue <= 0)
        {
            Direction = Vector2.zero;
            myRigidbody.velocity = Direction;
            isDead = true;
            Animator.SetBool("die", isDead);
            // animator.SetTrigger("die");
            //die
        }
    }



    public void MoveDown()
    {
        ExitIndex = 0;
        Direction += Vector2.down;
    }

    public void MoveLeft()
    {
        ExitIndex = 1;
        Direction += Vector2.left;
    }

    public void MoveRight()
    {
        ExitIndex = 2;
        Direction += Vector2.right;
    }

    public void MoveUp()
    {
        ExitIndex = 3;
        Direction += Vector2.up;

    }

    public void Stop()
    {
        Direction = Vector2.zero;
    }
}
