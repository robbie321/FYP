using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the player script, it contains functionality that is specific to the Player
/// </summary>
public class Player : Character
{
    private Vector3 min, max;
    /// <summary>
    /// The player's health
    /// </summary>
    [SerializeField]
    private StatBar health;
    /// <summary>
    /// The player's mana
    /// </summary>
    [SerializeField]
    private StatBar shield;

    /// <summary>
    /// The player's initialHealth
    /// </summary>
    [SerializeField]
    private float initHealth;

    /// <summary>
    /// The player's initial mana
    /// </summary>
    [SerializeField]
    private float initShield;

    private IInventoryItem mCurrentItem = null;
    private bool mLockPickup = false;
    public Inventory inventory;
    public HUD Hud;

    [SerializeField]
    private GameObject[] spellPrefabs;

    //exit points for spells
    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex = 0;

    protected override void Start()
    {

        health.Initialize(initHealth, initHealth);
        shield.Initialize(initShield, initShield);

        base.Start();
    }

    /// <summary>
    /// We are overriding the characters update function, so that we can execute our own functions
    /// </summary>
    protected override void Update()
    {
        //Executes the GetInput function
        GetInput();
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

    /// <summary>
    /// Listen's to the players input
    /// </summary>
    private void GetInput()
    {
        direction = Vector2.zero;

        ///THIS IS USED FOR DEBUGGING ONLY
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
            if (!isAttacking && !IsMoving) //Chcks if we are able to attack
            {
                //coroutine is used to do something at the same time the script is running
                attackRoutine = StartCoroutine(Attack());
            }
        }
    }
    //----ATTACK AND SPELLS----
    /// <summary>
    /// A co routine for attacking
    /// </summary>
    /// <returns></returns>
    private IEnumerator Attack()
    {
        isAttacking = true; //Indicates if we are attacking

        animator.SetBool("attack", isAttacking); //Starts the attack animation

        yield return new WaitForSeconds(1); //This is a hardcoded cast time, for debugging

        CastSpell();

        StopAttack(); //Ends the attack
    }

    public void CastSpell()
    {
        Instantiate(spellPrefabs[0], exitPoints[exitIndex].position, Quaternion.identity);
    }


    //----INVENTORY----
    private IInventoryItem mItemToPickup = null;

    private void OnTriggerEnter2D(Collider2D other)
    {

        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            if (mLockPickup)
                return;

            mItemToPickup = item;

            //inventory.AddItem(item);
            //item.OnPickup();
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

        // _animator.SetTrigger("tr_drop");

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
