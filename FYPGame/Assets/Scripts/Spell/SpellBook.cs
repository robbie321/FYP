using System;
using System.Collections;
using UnityEngine;


public class SpellBook : MonoBehaviour
{
    private static SpellBook instance;

    public static SpellBook MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpellBook>();
            }

            return instance;
        }
    }
    //A reference to the spell name on the casting bar
    [SerializeField]
    private string currentSpell;
    [SerializeField]
    private string spellName;
    //All spells in the spellbook
    [SerializeField]
    private Spell[] spells;
    //A reference to the coroutine that throws spells
    private Coroutine spellRoutine;
    //Cast a spell at an enemy
    public Spell CastSpell(int index)
    {
        spellName = spells[index].Name;
        //Spell spell = Array.Find(spells, x => x.Name == spellName);
        //Changes the text on the bar so that we can read what spell we are casting
        currentSpell = spellName;
        //Starts casting the spells
        spellRoutine = StartCoroutine(Progress(index));
        //Returns the spell that we just  cast.
        return spells[index];
    }

    private IEnumerator Progress(int index)
    {
        //How much time has passed since we started casting the spell
        float timePassed = Time.deltaTime;
        float rate = 1.0f / spells[index].CastTime;

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
        Spell spell = Array.Find(spells, x => x.Name == spellName);

        return spell;
    }
}
