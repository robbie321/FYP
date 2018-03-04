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
    protected float speed;
    // A reference to the character's animator
    protected Animator animator;
    //The Player's direction
    protected Vector2 direction;
    //The Character's rigidbody
    protected Rigidbody2D myRigidbody;
    // indicates if the character is attacking or not
    protected bool isAttacking = false;
    protected bool isDead = false;
    // A reference to the attack coroutine
    protected Coroutine attackRoutine;
    //character hitBox for selecting
    [SerializeField]
    protected Transform hitBox;
    // The player's initialHealth
    [SerializeField]
    private float initHealth;
    [SerializeField]
    protected StatBar health;
    // Indicates if character is moving or not
    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected virtual void Start()
    {
        //Makes a reference to the rigidbody2D
        myRigidbody = GetComponent<Rigidbody2D>();

        //Makes a reference to the character's animator
        animator = GetComponent<Animator>();

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
        //Makes sure that the player moves
        myRigidbody.velocity = direction.normalized * speed;
    }
    //Makes sure that the right animation layer is playing
    public void HandleLayers()
    {
        //Checks if we are moving or standing still, if we are moving then we need to play the move animation
        if (IsMoving)
        {
            ActivateLayer("Walk Layer");

            //Sets the animation parameter so that he faces the correct direction
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);

            //StopAttack();
        }
        else if (isAttacking)
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
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }
    // Stops the attack
    public void StopAttack()
    {
        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);

            isAttacking = false; //Makes sure that we are not attacking

            animator.SetBool("attack", isAttacking); //Stops the attack animation
        }

    }
    public virtual void TakeDamage(float damage)
    {
        //reduce health
        health.PlayerCurrentValue -= damage;
        if (health.PlayerCurrentValue <= 0)
        {
            isDead = true;
            animator.SetBool("die", isDead);
            // animator.SetTrigger("die");
            //die
        }
    }
}
