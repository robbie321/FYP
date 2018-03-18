using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private string spellName;
    //Everytime you click on button in spell book
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            //pick up the spell
            //returns spell to handlebuttonclick TakeMoveable
            HandleButtonClick.MyInstance.TakeMoveable(SpellBook.MyInstance.GetSpell(spellName));
        }
    }
}
