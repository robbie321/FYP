using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : Singleton<StatBar>
{
    // The actual image that we are chaing the fill of
    private Image content;
    // A reference to the value text on the bar
    [SerializeField]
    private Text statValue;
    // Hold the current fill value, we use this, so that we know if we need to lerp a value
    private float currentFill;
    //The lerp speed
    [SerializeField]
    private float lerpSpeed;
   // The stat's MaxValue for example max health or mana
    public float MaxValue { get; set; }
    //The currentValue for example the current health or mana
    private float currentValue;
    private float currentXP;
    private int currentLevel;
    //private float totalXP;
    //Property for setting the current value, this has to be used every time we change the
    //currentValue, so that everything updates correctly
    //Used to access currentValue from different scripts
    public float PlayerCurrentValue
    {
        get
        {

            return currentValue;
        }

        set
        {
            if (value >= MaxValue)//Makes sure that we don't get too much health
            {
                if(gameObject.name == "XP")
                {
                    currentValue = 0;
                    MaxValue = MaxValue * 2;
                    currentLevel++;
                }else
                currentValue = MaxValue;
            }
            else if (value < 0) //Makes sure that we don't get health below 0
            {
                currentValue = 0;
            }
            else //Makes sure that we set the current value withing the bounds of 0 to max health
            {
                currentValue = value;
            }

            //Calculates the currentFill, so that we can lerp
            currentFill = currentValue / MaxValue;
            
            if (statValue != null)
            {
                if (gameObject.name == "XP") {
                    statValue.text = "Level: " + currentLevel + "    " + currentValue + " / " + MaxValue + "  ";
                }
                else
                //Makes sure that we update the value text
                statValue.text = currentValue + " / " + MaxValue;

            }
           

        }
    }

    void Start()
    {
        //Creates a reference to the content
        content = GetComponent<Image>();
    }

    void Update()
    {
        //update the bar
        HandleBar();
    }

    // Initialises the bar
    //current and max value of bar
    public void Initialize(float currentValue, float maxValue)
    {
        if (content == null)
        {
            content = GetComponent<Image>();
        }
        
        MaxValue = maxValue;
        PlayerCurrentValue = currentValue;
        content.fillAmount = PlayerCurrentValue / MaxValue;
    }


    // Makes sure that the bar updates
    private void HandleBar()
    {
        if (currentFill != content.fillAmount) //If we have a new fill amount then we know that we need to update the bar
        {
            //Lerps the fill amount so that we get a smooth movement
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }

    }
}
