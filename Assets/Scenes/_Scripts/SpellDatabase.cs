using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpellDatabase", menuName = "Scriptable Objects/SpellDatabase")]
public class SpellDatabase : ScriptableObject // Spell database efficient intialization fully done by Microsoft Copilot
{
    public List<Spell> spells;
    private Dictionary<string, Spell> lookup;

    private void OnEnable()
    {
        lookup = new Dictionary<string, Spell>();
        foreach (var spell in spells)
            lookup[spell.spellName] = spell;
    }

    public bool TryGetSpell(string input, out Spell spell)
        => lookup.TryGetValue(input, out spell);


}
