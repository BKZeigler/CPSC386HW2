using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] 
    private float maxHealth = 100f;
    [SerializeField] 
    private float currentHealth;

    private HealthBar healthBar;

    private GameState gameState;


    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // Initialize health bar reference
        gameState = FindFirstObjectByType<GameState>(); // Intiailize game state reference
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // set current health to max health at the start of each fight
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
}
