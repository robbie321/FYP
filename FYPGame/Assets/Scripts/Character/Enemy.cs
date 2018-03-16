using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    /// <summary>
    /// A canvasgroup for the healthbar
    /// </summary>
    [SerializeField]
    private CanvasGroup healthGroup;

    private IState currentState;

    private float attackRange;

    private float attackTime;

   

    public float AttackRange
    {
        get
        {
            return attackRange;
        }

        set
        {
            attackRange = value;
        }
    }

    public float AttackTime
    {
        get
        {
            return attackTime;
        }

        set
        {
            attackTime = value;
        }
    }

    protected void Awake()
    {
 
        
        AttackRange = 2;
        ChangeState(new IdleState());
    }

    protected override void Update()
    {
        if (!isDead)
        {
            if (!IsAttacking)
            {
                attackTime += Time.deltaTime;
            }
            currentState.Update();
        }
       
        base.Update();
    }
    //When the enemy is selected

    public override Transform Select()
    {
        //Shows the health bar
        healthGroup.alpha = 1;

        return base.Select();
    }
    // When we deselect our enemy
    public override void DeSelect()
    {
        //Hides the healthbar
        healthGroup.alpha = 0;

        base.DeSelect();
    }

    // Makes the enemy take damage when hit
    public override void TakeDamage(float damage, Transform source)
    {
        if (!(currentState is EvadeState))
        {
           // SetTarget(source);

            base.TakeDamage(damage, source);

           // OnHealthChanged(health.MyCurrentValue);
        }

    }

    public void ChangeState(IState newState)
    {
         
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }
}
