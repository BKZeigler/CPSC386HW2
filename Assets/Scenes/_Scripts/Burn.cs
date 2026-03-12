using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Effects/Burn")]

 

public class Burn : SpellEffect
{

    public float damage;
    public override void ApplyEffect(Boss boss)
    {
        Tick.Instance.StartCoroutine(Tick.Instance.StartTick(boss, damage));
    }

    public override void ApplyEffect(Player player)
    {
        Tick.Instance.StartCoroutine(Tick.Instance.StartTick(player, damage));
    }
}
