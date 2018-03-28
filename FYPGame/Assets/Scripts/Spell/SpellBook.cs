using System;
using System.Collections;
using UnityEngine;


public class SpellBook : Singleton<SpellBook>
{
    private string spellName;
    //All spells in the spellbook
    [SerializeField]
    private Spell[] spells;
    //A reference to the coroutine that throws spells
    private Coroutine spellRoutine;
    //Cast a spell at an enemy
    public Spell CastSpell(string spellName)
    {
        Spell spell = Array.Find(spells, x => x.Name == spellName);
        spellRoutine = StartCoroutine(Progress(spell));
        //Returns the spell that we just  cast.
        return spell;
    }

    private IEnumerator Progress(Spell spell)
    {
        //How much time has passed since we started casting the spell
        float timePassed = Time.deltaTime;
        float rate = 1.0f / spell.CastTime;

        //The current progress of the cast 
        float progress = 0.0f;

        while (progress <= 1.0)//As long as we are not done casting
        {
            //Increases the progress
            progress += rate * Time.deltaTime;
            //Updates the time passed
            timePassed += Time.deltaTime;
            yield return null;
        }
        StopCating();//Stops our cast when we are done
    }
    //Stops a cast
    public void StopCating()
    {
        //Stops the spellroutine
        if (spellRoutine != null)
        {
            StopCoroutine(spellRoutine);
            spellRoutine = null;
        }
    }

    public Spell GetSpell(string spellName)
    {
        //check for the name of the gameobject and see if matches
        Spell spell = Array.Find(spells, x => x.Name == spellName);

        return spell;
    }
}
