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

    }



}
