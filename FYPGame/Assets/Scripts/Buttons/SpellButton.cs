using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private string spellName;
    Spell spell;
    Image image;
    [SerializeField]
    int value;
    void Start()
    {
        image = gameObject.GetComponentInParent<Image>();
        spell = SpellBook.MyInstance.GetSpell(spellName);
    }
    void Update()
    {
        UnlockSpell();
    }
    //Everytime you click on button in spell book
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left && spell.Unlocked == true)
        {
            //pick up the spell
            //returns spell to handlebuttonclick TakeMoveable
            HandleButtonClick.MyInstance.TakeMoveable(SpellBook.MyInstance.GetSpell(spellName));
        }
    }
    public void UnlockSpell()
    {
     
            if (spell.Unlocked != true)
            {
                image.color = Color.grey;
            }
            else
                image.color = Color.white;

        
    }

    public void UseXP()
    {
        if(Player.Instance.XP.PlayerCurrentValue > value)
        {
            Player.Instance.XP.PlayerCurrentValue -= value;
            spell.Unlocked = true;
           // gameObject.GetComponentInParent<Button>().gam.SetActive(false);
        }
    }

}
