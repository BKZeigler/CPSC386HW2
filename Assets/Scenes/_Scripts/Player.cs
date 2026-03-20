using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] 
    private float maxHealth = 100f; //stores max hp
    [SerializeField] 
    private float currentHealth; // stores current hp

    private HealthBar healthBar; // stores hp bar

    private Settings settings; // stores settings

    public Boss currentBoss; // stores current boss

    private SpellSelector spellSelector; // stores the "wand" or spell selector

    private Dictionary<Spell, bool> cooldowns = new(); // stores cooldowns for each spell

    public Animator animator; // stores the animator for spells

    public TextMeshProUGUI fireballCooldown; // hardcoded fireball cd
    public TextMeshProUGUI lightningCooldown; // hardcoded lightning cd

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // Initialize health bar reference
        settings = FindFirstObjectByType<Settings>(); // Intiailize settingsreference
        currentBoss = FindFirstObjectByType<Boss>(); // Initialize boss reference
        spellSelector = FindFirstObjectByType<SpellSelector>(); // Initialize spell selector reference
        animator = FindFirstObjectByType<Animator>(); // Initialize animator reference
    }
    void Start()
    {
        currentHealth = maxHealth; // set current health to max health at the start of each fight
        spellSelector.ReSelectField(); // make sure the wand is always selected at the start of each fight
    }
    void Update()
    {
        
    }

    public void TakeDamage(float damage) // called when boss damages player
    {
        currentHealth -= damage; // reduce hp by damage dealt
        healthBar.UpdateHealthBar(currentHealth, maxHealth); // update health bar when taking damage

        if (currentHealth <= 0) // if hp is 0 or below
        {
            Die();  // Die when hp is 0 or below
        }
    }

    public void LaunchSpell(string spellName) // called when a correct input is recieved from spell checker
    {
        var spellDatabase = Resources.Load<SpellDatabase>("SpellDatabase"); // load database
        var spell = spellDatabase.TryGetSpell(spellName); // find that spell in database

        if(CanCast(spell)) // if spell not on cd
        {
            StartCooldown(spell); // start the cd
            if (spell.effect != null) // if the spell has an effect
                {
                    spell.effect.ApplyEffect(currentBoss); // apply it to boss
                }
            if (spell.animationClip != null) // if the spell has an animation
                {
                    animator.Play(spell.animationClip.name, 0, 0f); // play the animation from start
                }
            currentBoss.TakeDamage(spell.damage); // deal damage to boss based on spell
        }else // if on cd
        {
            Debug.Log("Spell is on cooldown.");
            return; // do nothing
        }

    }

    public bool CanCast(Spell spell) // checks if spell can be casted
    {
        return cooldowns.ContainsKey(spell) == false || cooldowns[spell] == false || spell.cooldown == 0f; // if cooldown does not exist or is false
    }

    public void StartCooldown(Spell spell) // called when spell with cd is casted
    {
        StartCoroutine(CooldownRoutine(spell)); // calls the coroutine that handles cooldowns
    }

    private IEnumerator CooldownRoutine(Spell spell)
    {
        cooldowns[spell] = true; // set cooldownt to true
        TextMeshProUGUI targetText = null; // prepare to update the relevant cooldown text
        if (spell.spellName == "FIREBALL") // hardcoded for now
        {
            targetText = fireballCooldown; // make the fireball cooldown text the target to update
        }
        else if (spell.spellName == "LIGHTNING") // hardcoded for now
        {
            targetText = lightningCooldown; // make the lightning cooldown text the target to update
        }
        else if(spell.spellName == "MISSILE") // hardcoded for now
        {
            targetText = null; // missile has no cd text to update
        }

        float timeLeft = spell.cooldown; //store the spells cd in timeLeft

        while (timeLeft > 0) // while the cd is still going
        {
            targetText.text = $"{spell.spellName} Cooldown: {Mathf.Ceil(timeLeft)}"; // display text with spell and cd
            timeLeft -= Time.deltaTime; // reduce time left by time since last frame
            yield return null; // wait until next frame to continue the loop
        }
        if (targetText != null) // if not missile
        {
            targetText.text = ""; // clear the text when cd is done
        }
        cooldowns[spell] = false; // set cooldown to false when done
    }

    public void Die() // called when player hp reaches 0 or below
    {
        BossProgress.Instance.ClearProgress(); // clear progress on player death
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lose"); // you lose when you die
    }



}
