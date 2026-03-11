using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Effects/Stun")]
public class Stun : SpellEffect
{
    public override void ApplyEffect(Boss boss)
    {
        boss.attackTimer += 2f;
        Debug.Log("Boss Stunned");
    }

    public override void ApplyEffect(Player player)
    {
    }
}
