using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonClick : MonoBehaviour {

	public void OnButtonClicked()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
    }

}
