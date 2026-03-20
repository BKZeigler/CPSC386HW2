using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Scriptable Objects/Spell")]
public class Spell : ScriptableObject
{
    public string id; // stores id for the spell
    public string spellName; // SHOULD ALWAYS BE UPPERCASE FOR MATCH TO WORK
    public float cooldown; // stores cd of the spell
    public float damage; // stores damage of the spell
    public SpellEffect effect; // stores any special effects
    public AnimationClip animationClip; // stores unique animation
}
