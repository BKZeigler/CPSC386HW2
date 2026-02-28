using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Scriptable Objects/Spell")]
public class Spell : ScriptableObject
{
    public string id;
    public string spellName; // SHOULD ALWAYS BE UPPERCASE FOR MATCH TO WORK
    public float cooldown;
    // public SpellEffect effect; // Will be replaced by polymorphic behavior for healing/stunning/etc.
}
