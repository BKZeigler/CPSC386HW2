using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Effects/Stun")]
public class Stun : SpellEffect
{
    public override void ApplyEffect(Boss boss)
    {
        boss.attackTimer += 2f; // increase attack timer of boss by 2 seconds, a stun
    }

    public override void ApplyEffect(Player player) // player stun not implemented yet
    {
    }
}
