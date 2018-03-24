using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// This is the player script, it contains functionality that is specific to the Player
public class Player : Character, IUseable
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }

            return instance;
        }
    }

    public Sprite Icon
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public IUseable Useable { get; set; }
    // public static Player instance;
    private Vector3 min, max;
    // The player's mana
    [SerializeField]
    public StatBar shield;
    // The player's initial mana
    [SerializeField]
    private float initShield;
    // The player's mana
    [SerializeField]
    public StatBar XP;
    // The player's initial mana
    [SerializeField]
    public float initXP;
    //reference to HUD
    public HUD Hud;
    //The players sight block
    [SerializeField]
    private SightBlock[] sightBlocks;


    //index to keep track of what exit point to use, 0 is defaulted as down
    //private int exitIndex = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    protected override void Start()
    {
        //get the current health total stored in GameManager.instance between scenes
        //GameManager.instance.playerHealth = health.PlayerCurrentValue;
        //get the current mana total stored in GameManager.instance between scenes
        //GameManager.instance.playerMana = shield.PlayerCurrentValue;
        shield.Initialize(initShield, 100);
        XP.Initialize(initXP, 100);
        base.Start();
    }

    // We are overriding the characters update function, so that we can execute our own functions
    protected override void Update()
    {
        
        //Executes the GetInput function
        //GetInput();
        //Clamps the player inside the tilemap
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x),
        Mathf.Clamp(transform.position.y, min.y + 4, max.y),
        transform.position.z);

        if (IsMoving)
        {
            StopAttack();
        }
        base.Update();
    }

 
    //----ATTACK AND SPELLS----
    // A co routine for attacking
    private IEnumerator Attack(string spellName)
    {
        Spell newSpell = SpellBook.MyInstance.CastSpell(spellName);
        Transform currentTarget = Target;
        IsAttacking = true; //Indicates if we are attacking

        Animator.SetBool("attack", IsAttacking); //Starts the attack animation

        yield return new WaitForSeconds(newSpell.CastTime); 
        //set the players target
        if (currentTarget != null && RaycastSight())
        {
            SpellScript spell = Instantiate(newSpell.SpellPrefab, ExitPoints[ExitIndex].position, Quaternion.identity).GetComponent<SpellScript>();
            //set spell target to players target
            spell.Initialize(currentTarget, newSpell.Damage, transform);
            shield.PlayerCurrentValue -= 5;
        }
        StopAttack(); //Ends the attack
    }
    //cast a spell
    public void CastSpell(string spellName)
    {
        if (shield.PlayerCurrentValue > 0)
        {
            BlockView();
            if (Target != null && !IsAttacking && !IsMoving && RaycastSight()) //Chcks if we are able to attack and in line of sight
            {
                //coroutine is used to do something at the same time the script is running
                attackRoutine = StartCoroutine(Attack(spellName));
            }
        }
    }
    //use a RayCast line to see if we are in the line of sigh to hit an enemy
    private bool RaycastSight()
    {
        if (Target != null)
        {
            //calculate direction

            Vector3 targetDirection = (Target.position - transform.position).normalized;
            //cast a ray from the player to our target
            //make sure the raycast can only hit our blocks and not the player by creating a new layer called block(9)
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Vector2.Distance(transform.position, Target.position), 512);
            //if we didnt hit the bloack, then we can cast a spell
            if (hit.collider == null)
            {

                return true;
            }

        }
        //if we hit the block we cant cast a spell
        return false;

    }

    private void BlockView()
    {
        foreach (SightBlock sb in sightBlocks)
        {
            sb.DeactivateBlock();
        }
        //exit index keeps track of where we are facing
        //based on direction it will enable the blocks for that direction
        sightBlocks[ExitIndex].ActivateBlock();
    }

    // Stops the attack
    public void StopAttack()
    {
        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);

            IsAttacking = false; //Makes sure that we are not attacking

            Animator.SetBool("attack", IsAttacking); //Stops the attack animation
        }

    }

    public void OnClick()
    {
        //so we can use our spells
        //if slot on action bar is not empty
        if (Useable != null)
        {
            Useable.Use();
        }
    }

    //----CAMERA----
    //camera tells the player its min and max values
    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }
}
