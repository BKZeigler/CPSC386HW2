using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Effects/Burn")]

 

public class Burn : SpellEffect // a spell effect that applies a DOT
{

    public float damage; // damage per tick
    public override void ApplyEffect(Boss boss) // applies spell's effects
    {
        Tick.Instance.StartCoroutine(Tick.Instance.StartTick(boss, damage)); // start a burning tick
    }

    public override void ApplyEffect(Player player) // applies spells effect to players, not used yet
    {
        Tick.Instance.StartCoroutine(Tick.Instance.StartTick(player, damage)); // start a burning tick on player
    }
}
