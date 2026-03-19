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

    private Settings settings;

    public Boss currentBoss;

    private SpellSelector spellSelector;

    private Dictionary<Spell, bool> cooldowns = new();


    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // Initialize health bar reference
        settings = FindFirstObjectByType<Settings>(); // Intiailize settingsreference
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
            Die();  // Die when hp is 0 or below
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
            if (spell.animationClip != null)
                {
                    var animator = FindFirstObjectByType<Animator>();
                    animator.Play(spell.animationClip.name);
                }
            currentBoss.TakeDamage(spell.damage);
        }else
        {
            Debug.Log("Spell is on cooldown.");
            // play error sound effect
            return;
        }

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

    public void Die()
    {
        BossProgress.Instance.ClearProgress(); // clear progress on player death
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lose"); // you lose when you die
    }



}
