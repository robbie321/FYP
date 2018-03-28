using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IItem {
    public string name;
    //public string Name { get; set; }
    [SerializeField]
    protected int value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Use();
        }
    }
    public virtual void Use()
    {
        //Use Item
    }

    public void OnDestroy()
    {
        UIManager.ItemEquipped(this);
    }

}
