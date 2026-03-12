using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Scriptable Objects/Spell")]
public class Spell : ScriptableObject
{
    public string id;
    public string spellName; // SHOULD ALWAYS BE UPPERCASE FOR MATCH TO WORK
    public float cooldown;
    public float damage;
    public SpellEffect effect; // Will be replaced by polymorphic behavior for healing/stunning/etc.
    public bool isOnCooldown = false;

    public virtual void StartCooldown()
    {
        Debug.Log("Cool down started for spell: " + spellName);
        var remainingCooldown = cooldown;
        isOnCooldown = true;
        while (remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
        isOnCooldown = false;
    }
}
