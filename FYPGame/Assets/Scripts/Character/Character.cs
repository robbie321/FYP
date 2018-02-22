﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
public abstract class Character : MonoBehaviour
{

    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    protected float speed;

    /// <summary>
    /// A reference to the character's animator
    /// </summary>
    protected Animator animator;

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    /// <summary>
    /// The Character's rigidbody
    /// </summary>
    protected Rigidbody2D myRigidbody;

    /// <summary>
    /// indicates if the character is attacking or not
    /// </summary>
    protected bool isAttacking = false;

    /// <summary>
    /// A reference to the attack coroutine
    /// </summary>
    protected Coroutine attackRoutine;

    /// <summary>
    /// Indicates if character is moving or not
    /// </summary>
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
    }

    /// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        myRigidbody.velocity = direction.normalized * speed;
    }

    /// <summary>
    /// Makes sure that the right animation layer is playing
    /// </summary>
    public void HandleLayers()
    {
        //Checks if we are moving or standing still, if we are moving then we need to play the move animation
        if (IsMoving)
        {
            ActivateLayer("Walk Layer");

            //Sets the animation parameter so that he faces the correct direction
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);

            StopAttack();
        }
        else if (isAttacking)
        {
            ActivateLayer("Attack Layer");
        }
        else
        {
            //Makes sure that we will go back to idle when we aren't pressing any keys.
            ActivateLayer("Idle Layer");
        }
    }

    /// <summary>
    /// Activates an animation layer based on a string
    /// </summary>
    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }

    /// <summary>
    /// Stops the attack
    /// </summary>
    public void StopAttack()
    {
        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);

            isAttacking = false; //Makes sure that we are not attacking

            animator.SetBool("attack", isAttacking); //Stops the attack animation
        }

    }
}