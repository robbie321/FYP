using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    // A reference to the state's parent
    private Enemy parent;

    private float attackCooldown = 1.5f;
    //little distance before enemy starts to follow player after outside attack range
    private float extraRange = .1f;

    //The state's constructor
    public void Enter(Enemy parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        Debug.Log("Attacking");

        //Makes sure that we only attack when we are off cooldown
        if (parent.AttackTime >= attackCooldown && !parent.IsAttacking)
        {
            //Resets the attack timer
            parent.AttackTime = 0;

            //Starts the attack
            parent.StartCoroutine(Attack());
        }

        if (parent.Target != null) //If we have a target then we need to check if we can attack it or if we need to follow it
        {
            //calculates the distance between the target and the enemy
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);

            //If the distance is larget than the attackrange, then we need to move
            if (distance >= parent.AttackRange + extraRange && !parent.IsAttacking)
            {
                //Follows the target
                parent.ChangeState(new FollowState());
            }


        }
        else//If we lost the target then we need to idle
        {
            parent.ChangeState(new IdleState());
        }
    }
    // Makes the enemy attack the player
    public IEnumerator Attack()
    {
        Spell newSpell = SpellBook.MyInstance.CastSpell("Fire");
        Transform currentTarget = parent.Target;
        parent.IsAttacking = true;

        parent.Animator.SetTrigger("attack");
        //gets attack layer from animator(2)
        yield return new WaitForSeconds(parent.Animator.GetCurrentAnimatorStateInfo(2).length);
        SpellScript spell = GameObject.Instantiate(newSpell.SpellPrefab, parent.ExitPoints[parent.ExitIndex].position, Quaternion.identity).GetComponent<SpellScript>() as SpellScript;
        //set spell target to players target
        spell.Initialize(currentTarget, newSpell.Damage, parent.transform);

        parent.IsAttacking = false;
    }

}
