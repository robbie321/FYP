using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButtons : MonoBehaviour, IPointerClickHandler {
    
    public IUseable Useable { get; set; }
    public Button Button { get; set; }

    public Image Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    [SerializeField]
    private Image icon;
    // Use this for initialization
    void Start () {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        //so we can use our spells
        //if slot on action bar is not empty
        if(Useable != null)
        {
            Useable.Use();
        }
        else
        {
            Debug.Log("Useable is equal to null");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //clicking left button
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            /*check if we are carrying something and it isnt null && 
             * check is moveable is an IUsable before setting it to IUsable
             * (if we can use selected item in action bar)*/
            if(HandleButtonClick.MyInstance.Moveable != null && HandleButtonClick.MyInstance.Moveable is IUseable)
            {
                SetUseable(HandleButtonClick.MyInstance.Moveable as IUseable);
            }
        }
    }


    public void SetUseable(IUseable useable)
    {
        Useable = useable;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        //the icon we want to place will be put into that slot
        Icon.sprite = HandleButtonClick.MyInstance.PlaceIcon().Icon;
        //white so we can see the button
        Icon.color = Color.white;
    }

}
