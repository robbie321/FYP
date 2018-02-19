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
    //private StatBar health;
    protected override void Start() {
        health.Initialize(initHealth, initHealth);
        shield.Initialize(initShield, initShield);
       // coin.InitializeCoin(initCoin);
        base.Start();
    }
    // Update is called once per frame
    //Player overrides character update
    protected override void Update () {
       GetKeyInput();
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,min.x,max.x), 
            Mathf.Clamp(transform.position.y, min.y + 4, max.y),
            transform.position.z);
        //Executes Character.cs Update
        base.Update();
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
}
