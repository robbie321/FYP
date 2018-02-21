using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    private Vector3 min, max;
    //players health
    [SerializeField]
    protected StatBar health, shield, coin;
    [SerializeField]
    private float initHealth;
    [SerializeField]
    private float initShield;
    [SerializeField]
    private int initCoin;
    private IInventoryItem mCurrentItem = null;
    private bool mLockPickup = false;
    public Inventory inventory;
    public HUD Hud;
    //private StatBar health;
    protected override void Start() {
        health.Initialize(initHealth, initHealth);
        shield.Initialize(initShield, 100);
        inventory.ItemRemoved += Inventory_ItemRemoved;
        // coin.InitializeCoin(initCoin);
        base.Start();
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

    public void DoDropItem()
    {
        mLockPickup = false;

        // Remove Rigidbody
        Destroy((mCurrentItem as MonoBehaviour).GetComponent<Rigidbody>());

        mCurrentItem = null;
    }

    void FixedUpdate()
    {
        // Drop item
        if (mCurrentItem != null && Input.GetKeyDown(KeyCode.R))
        {
            DropCurrentItem();
        }
    }
    // Update is called once per frame
    //Player overrides character update
    protected override void Update () {
       GetKeyInput();
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,min.x,max.x), 
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

        //Executes Character.cs Update
        base.Update();
	}

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




    private void GetKeyInput()
    {
        //direction reset after each loop
        direction = Vector2.zero;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            direction = Vector2.up;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = Vector2.left;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            direction = Vector2.down;
        }

        if (Input.GetAxisRaw("Horizontal") >0)
        {
            direction = Vector2.right;
        }
        //HEALTH DEBUGGING
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.PlayerCurrentValue -= 10;
            shield.PlayerCurrentValue -= 10;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            health.PlayerCurrentValue += 10;
            shield.PlayerCurrentValue += 10;
        //    coin.CurrentCoinValue -= 10;
        }
    }
    //camera tells the player its min and max values
    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }

   
    /*private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Item"))
         {
             IInventoryItem item = collision.GetComponent<IInventoryItem>();
             if (item != null)
             {
                 Debug.Log("Item Picked up");
                 inventory.AddItem(item);
             }
         }

     }*/
    
     /*   private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            //check if item has an IInventoryItem attached
            IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
            if(item != null)
            {
                inventory.AddItem(item);
            }
        }*/
}
