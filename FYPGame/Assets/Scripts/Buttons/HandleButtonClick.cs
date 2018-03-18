using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleButtonClick : MonoBehaviour {
    private static HandleButtonClick instance;

    public static HandleButtonClick MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HandleButtonClick>();
            }

            return instance;
        }
    }
    //when carrying an object, it has a icon
    public IMoveable Moveable { get; set; }
    //icon shown
    private Image icon;
    //add offset for mouse position
    [SerializeField]
    Vector3 offset;
	// Use this for initialization
	void Start () {
        icon = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
        icon.transform.position = Input.mousePosition+offset;
	}

    public void TakeMoveable(IMoveable moveable)
    {
        Moveable = moveable;
        icon.sprite = moveable.Icon;
        icon.color = Color.white;
    }

    public IMoveable PlaceIcon()
    {
        IMoveable temp = Moveable;
        Moveable = null;
        //transparent, to remove the moving icon
        icon.color = new Color(0, 0, 0, 0);
        return temp;
    }
}
