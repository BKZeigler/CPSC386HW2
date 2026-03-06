using UnityEngine;

public class SpellChecker : MonoBehaviour // Takes input from spell grabber and tries to match it to a spell in the spell database
{
    public Player player;
    public void Start()
    {
        player = FindFirstObjectByType<Player>();
    }
    public void CheckSpell(string input)
    {
        var spellDatabase = Resources.Load<SpellDatabase>("SpellDatabase"); // recall the database of spells

        if (spellDatabase.TryGetSpell(input, out var spell)) // if spell name is found in database (spelled correctly)
        {
            Debug.Log($"Spell found: {spell.spellName} with cooldown {spell.cooldown}");
            // check if spell is on cooldown
            // if not, call spell's effect and start its cooldown
            player.LaunchSpell(spell.spellName);
        }
        else
        {
            Debug.Log("No spell found with that name.");
            Debug.Log("input received was " + input);
            // play error sound effect
        }
    }
}
