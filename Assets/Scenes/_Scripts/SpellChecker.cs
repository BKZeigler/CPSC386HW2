using UnityEngine;

public class SpellChecker : MonoBehaviour // Takes input from spell grabber and tries to match it to a spell in the spell database
{
    public Player player;
    public Boss boss;
    public void Start()
    {
        player = FindFirstObjectByType<Player>(); // find player
        boss = FindFirstObjectByType<Boss>(); // find boss
    }
    public void CheckSpell(string input)
    {
        var spellDatabase = Resources.Load<SpellDatabase>("SpellDatabase"); // recall the database of spells

        if (spellDatabase.TryGetSpell(input) != null) // if spell name is found in database (spelled correctly)
        {
            var spell = spellDatabase.TryGetSpell(input); // try to get spel from database
            player.LaunchSpell(spell.spellName); // launch that spell
        }
        else
        {
            if (boss.bossName == "Wrath" && input != "") // if the boss is wrath and a spell was attempted but misspelled
            {
                boss.damage += 10f; // enrage boss on misspelled spell
                var spriteRenderer = boss.GetComponent<SpriteRenderer>(); // get renderer for boss
                Color currentColor = spriteRenderer.color; // get its current color
                currentColor.g -= 0.2f; // tint it red
                currentColor.b -= 0.2f; // tint it red
                spriteRenderer.color = currentColor; // apply the color change
            }
        }
    }
}
