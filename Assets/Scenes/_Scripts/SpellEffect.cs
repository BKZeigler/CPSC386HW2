using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Effects")]
public abstract class SpellEffect : ScriptableObject
{
    public abstract void ApplyEffect(Boss boss); // effect application for boss
    public abstract void ApplyEffect(Player player); // effect application for player
}

