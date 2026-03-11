using UnityEngine;

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
        if (spell == null)
        {
            Debug.LogError("SPELL IS NULL");
            return;
        }

        if (spell.effect == null)
        {
            Debug.LogError("SPELL EFFECT IS NULL for spell: " + spell.spellName);
            return;
        }

        if (currentBoss == null)
        {
            Debug.LogError("CURRENT BOSS IS NULL");
            return;
        }

        spell.effect.ApplyEffect(currentBoss);
        currentBoss.TakeDamage(spell.damage);

    }
}
