using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Spell// : IUseable, IMoveable
{
    // The Spell's name
    [SerializeField]
    private string name;
    // The spell's damage
    [SerializeField]
    private int damage;
    //The spell's speed
    [SerializeField]
    private float speed;
    // The spell's cast time
    [SerializeField]
    private float castTime;
    // The spell's prefab
    [SerializeField]
    private GameObject spellPrefab;

    // Property for accessing the spell's name
    public string Name
    {
        get
        {
            return name;
        }
    }

    // Property for reading the damage
    public int Damage
    {
        get
        {
            return damage;
        }

    }
    // Property for reading the speed
    public float Speed
    {
        get
        {
            return speed;
        }
    }
    // Property for reading the cast time
    public float CastTime
    {
        get
        {
            return castTime;
        }
    }
    //Property for reading the spell's prefab
    public GameObject SpellPrefab
    {
        get
        {
            return spellPrefab;
        }
    }

    public void Use()
    {
        //Player.Instance.CastSpell(Name);
    }
}
