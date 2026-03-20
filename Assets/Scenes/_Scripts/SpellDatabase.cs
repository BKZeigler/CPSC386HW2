using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpellDatabase", menuName = "Scriptable Objects/SpellDatabase")]
public class SpellDatabase : ScriptableObject // Spell database efficient intialization fully done by Microsoft Copilot
{
    public List<Spell> spells;
    private Dictionary<string, Spell> lookup;

    private void OnEnable() // initialize lookup dictionary when the database is enabled
    {
        lookup = new Dictionary<string, Spell>(); // create new dictionary
        foreach (var spell in spells) // loop through all spells in the list
        {
            lookup[spell.spellName] = spell; // add spell to dictionary with spell name as key and spell object as value
        }
    }
    public Spell TryGetSpell(string input) // fetches spell from database
    {
        lookup.TryGetValue(input, out var spell); // look up sell by entered name
        if (spell != null) // if a spell was found
        {
            return spell; // return it
        }
        else // if not spelled corrrectly or not found
        {
            return null; // do nothing
        }

    }

}
