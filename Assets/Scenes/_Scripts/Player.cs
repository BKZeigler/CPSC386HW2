using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField] 
    private float maxHealth = 100f;
    [SerializeField] 
    private float currentHealth;

    private HealthBar healthBar;

    private GameState gameState;

    public Boss currentBoss;

    private SpellSelector spellSelector;

    private Dictionary<Spell, bool> cooldowns = new();


    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // Initialize health bar reference
        gameState = FindFirstObjectByType<GameState>(); // Intiailize game state reference
        currentBoss = FindFirstObjectByType<Boss>(); // Initialize boss reference
        spellSelector = FindFirstObjectByType<SpellSelector>(); // Initialize spell selector reference
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // set current health to max health at the start of each fight
        spellSelector.ReSelectField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth); // update health bar when taking damage

        if (currentHealth <= 0)
        {
            gameState.Lose();  // Call lose function when health drops below or equal to 0
        }
    }

    public void LaunchSpell(string spellName)
    {
        var spellDatabase = Resources.Load<SpellDatabase>("SpellDatabase");
        var spell = spellDatabase.TryGetSpell(spellName);

        if(CanCast(spell))
        {
            StartCooldown(spell);
            if (spell.effect != null)
                {
                    spell.effect.ApplyEffect(currentBoss);
                }
            currentBoss.TakeDamage(spell.damage);
        }else
        {
            Debug.Log("Spell is on cooldown.");
            // play error sound effect
            return;
        }
    
        //if (spell.effect != null)
        //{
        //    spell.effect.ApplyEffect(currentBoss);
        //}
        //currentBoss.TakeDamage(spell.damage);

    }

    public bool CanCast(Spell spell)
    {
        return cooldowns.ContainsKey(spell) == false || cooldowns[spell] == false; // if cooldown does not exist or is false
    }

    public void StartCooldown(Spell spell)
    {
        StartCoroutine(CooldownRoutine(spell));
    }

    private IEnumerator CooldownRoutine(Spell spell)
    {
        cooldowns[spell] = true;
        yield return new WaitForSeconds(spell.cooldown);
        cooldowns[spell] = false;
    }



}
