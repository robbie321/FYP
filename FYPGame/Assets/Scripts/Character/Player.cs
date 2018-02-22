using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is the player script, it contains functionality that is specific to the Player
public class Player : Character
{
    private Vector3 min, max;
    // The player's health
    [SerializeField]
    private StatBar health;
    // The player's mana
    [SerializeField]
    private StatBar shield;
    // The player's initialHealth
    [SerializeField]
    private float initHealth;
    // The player's initial mana
    [SerializeField]
    private float initShield;

    private IInventoryItem mCurrentItem = null;

    private bool mLockPickup = false;
    //reference to Inventory
    public Inventory inventory;
    //reference to HUD
    public HUD Hud;
    //array to store our spells
    [SerializeField]
    private GameObject[] spellPrefabs;
    //exit points for spells
    [SerializeField]
    private Transform[] exitPoints;
    //The players sight block
    [SerializeField]
    private SightBlock[] sightBlocks;
    //players target
    public Transform Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    //index to keep track of what exit point to use, 0 is defaulted as down
    private int exitIndex = 0;

    protected override void Start()
    {

        health.Initialize(initHealth, initHealth);
        shield.Initialize(initShield, initShield);
        // Target = GameObject.FindGameObjectWithTag("Target").transform;
        base.Start();
    }
    // We are overriding the characters update function, so that we can execute our own functions
    protected override void Update()
    {
        //Executes the GetInput function
        GetInput();
        //Clamps the player inside the tilemap
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x),
        Mathf.Clamp(transform.position.y, min.y + 4, max.y),
        transform.position.z);
        // Pickup item
        if (mItemToPickup != null && Input.GetKeyDown(KeyCode.F))
        {
            inventory.AddItem(mItemToPickup);
            mItemToPickup.OnPickup();
            Hud.CloseMessagePanel();

            mItemToPickup = null;
        }
        base.Update();
    }

    // Listen's to the players input
    private void GetInput()
    {
        direction = Vector2.zero;

        //THIS IS USED FOR DEBUGGING ONLY
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.PlayerCurrentValue -= 10;
            shield.PlayerCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.PlayerCurrentValue += 10;
            shield.PlayerCurrentValue += 10;
        }

        if (Input.GetKey(KeyCode.W)) //Moves up
        {
            exitIndex = 3;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) //Moves left
        {
            exitIndex = 1;
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 0;
            direction += Vector2.down;//Moves down
        }
        if (Input.GetKey(KeyCode.D)) //Moves right
        {
            exitIndex = 2;
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) //Makes the player attack
        {
            BlockView();
            if (Target != null && !isAttacking && !IsMoving && RaycastSight()) //Chcks if we are able to attack and in line of sight
            {
                //coroutine is used to do something at the same time the script is running
                attackRoutine = StartCoroutine(Attack());
            }
        }
    }
    //----ATTACK AND SPELLS----
    // A co routine for attacking
    private IEnumerator Attack()
    {
        isAttacking = true; //Indicates if we are attacking

        animator.SetBool("attack", isAttacking); //Starts the attack animation

        yield return new WaitForSeconds(1); //This is a hardcoded cast time, for debugging

        CastSpell();//casts spell

        StopAttack(); //Ends the attack
    }

    public void CastSpell()
    {
        Instantiate(spellPrefabs[0], exitPoints[exitIndex].position, Quaternion.identity);
    }
    //use a RayCast line to see if we are in the line of sigh to hit an enemy
    private bool RaycastSight()
    {
        //calculate direction

        Vector3 targetDirection = (Target.position - transform.position).normalized;
        //cast a ray from the player to our target
        //make sure the raycast can only hit our blocks and not the player by creating a new layer called block(9)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Vector2.Distance(transform.position, Target.position), 512);

        if (hit.collider == null)
        {

            return true;
        }
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
        sightBlocks[exitIndex].ActivateBlock();
    }

    //----INVENTORY----
    private IInventoryItem mItemToPickup = null;
    private Transform _target;

    private void OnTriggerEnter2D(Collider2D other)
    {

        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            if (mLockPickup)
                return;

            mItemToPickup = item;
            Hud.OpenMessagePanel("Click F");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            Hud.CloseMessagePanel();
            mItemToPickup = null;
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        goItem.transform.parent = null;
    }



    private void DropCurrentItem()
    {
        mLockPickup = true;

        GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;

        inventory.RemoveItem(mCurrentItem);

        // Throw animation
        Rigidbody rbItem = goItem.AddComponent<Rigidbody>();
        if (rbItem != null)
        {
            rbItem.AddForce(transform.forward * 2.0f, ForceMode.Impulse);

            Invoke("DoDropItem", 0.25f);
        }

    }
    //----CAMERA----
    //camera tells the player its min and max values
    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }


}
