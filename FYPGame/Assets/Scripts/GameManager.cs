using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//handles the targets and tells the player what we can click on
public class GameManager : MonoBehaviour {
    /// <summary>
    /// A reference to the player object
    /// </summary>
    [SerializeField]
    private Player player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ClickTarget();
	}

    private void ClickTarget()
    {
        //if left mouse id pressed and not pressed another game object
        //so will only throw a ray cast if mouse is not over a UI element
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            //Makes a raycast from the mouse position into the game world
            //direction, distance and layer
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 1024);
            if (hit.collider != null)//If we hit something
            {
                if(hit.collider.tag == "Enemy")
                {
                    player.Target = hit.transform;
                }
               
            }
            else
            {
                player.Target = null;
            }
        }
    }
}