using UnityEngine;
using UnityEngine.AdaptivePerformance;

[CreateAssetMenu(menuName = "Spells/Effects")]
public abstract class SpellEffect : ScriptableObject
{
    public abstract void ApplyEffect(Boss boss);
    public abstract void ApplyEffect(Player player);
}

