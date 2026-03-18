using UnityEngine;

public class SpellChecker : MonoBehaviour // Takes input from spell grabber and tries to match it to a spell in the spell database
{
    public Player player;
    public Boss boss;
    public void Start()
    {
        player = FindFirstObjectByType<Player>();
        boss = FindFirstObjectByType<Boss>();
    }
    public void CheckSpell(string input)
    {
        var spellDatabase = Resources.Load<SpellDatabase>("SpellDatabase"); // recall the database of spells

        if (spellDatabase.TryGetSpell(input) != null) // if spell name is found in database (spelled correctly)
        {
            var spell = spellDatabase.TryGetSpell(input);
            Debug.Log($"Spell found: {spell.spellName} with cooldown {spell.cooldown}");
            player.LaunchSpell(spell.spellName);
        }
        else
        {
            Debug.Log("No spell found with that name.");
            Debug.Log("input received was " + input);
            if (boss.bossName == "Wrath" && input != "") // if the boss is wrath and a spell was attempted but misspelled
            {
                boss.damage += 5f; // enrage boss on misspelled spell
                // tint sprite red to indicate enrage
                var spriteRenderer = boss.GetComponent<SpriteRenderer>();
                Color currentColor = spriteRenderer.color;
                currentColor.g -= 0.2f;
                currentColor.b -= 0.2f;
                spriteRenderer.color = currentColor;
                 

                Debug.Log("Wrath Boss enraged! Damage increased to " + boss.damage);
            }
            // play error sound effect
        }
    }
}
