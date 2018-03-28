using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    private float spawnRate = .2f;
    //potion and xp to drop
    [SerializeField]
    private GameObject potion;
    [SerializeField]
    private GameObject XP;
    /// <summary>
    /// A canvasgroup for the healthbar
    /// </summary>
    [SerializeField]
    private CanvasGroup healthGroup;

    private IState currentState;

    private float attackRange;

    private float attackTime;
    //initial range
    [SerializeField]
    private float initialRange;
    //Range player must travel
    public float Range { get; set; }
   
    public bool InRange
    {
        get
        {
            //if distance between enemy and player is < the Range, true
            return Vector2.Distance(transform.position, Target.position) < Range;
        }
    }

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

        Range = initialRange;
        AttackRange = 2;
        ChangeState(new IdleState());
    }

    protected override void Start()
    {
        base.Start();
        NPCID = 0;
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
           SetTarget(source);

            base.TakeDamage(damage, source);
        }

    }

    public override void ChangeState(IState newState)
    {
         
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }

    public void SetTarget(Transform target)
    {
        if(Target == null)
        {
            //calculate distance if enemy doesnt have target
            float distance = Vector2.Distance(transform.position, target.position);
            //reset every time a new one is set
            Range = initialRange;
            //range is then set on the distance
            Range += distance;
            Target = target;
        }
    }

    public void OnDestroy()
    {
        Vector3 newX = transform.position;
        newX.x = transform.position.x;
        CombatEvents.EnemyDied(this);
        for(int i = (Random.Range(0,3)); i < 3; i++){
            Instantiate(XP, newX, transform.rotation);
            newX.x = newX.x + 0.2f;
        }
        if (Random.Range(0f,1f) < spawnRate)
        {
            Instantiate(potion, transform.position, transform.rotation);
            
        }
        
    }
}
