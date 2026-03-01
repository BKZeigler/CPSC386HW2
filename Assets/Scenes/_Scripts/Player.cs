using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] 
    private float maxHealth = 100f;
    [SerializeField] 
    private float currentHealth;

    private HealthBar healthBar;

    GameState gameState;


    private void Awake()
    {
        healthBar = FindFirstObjectByType<HealthBar>(); // Initialize health bar reference
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // set current health to max health at the start of each fight

        gameState = FindFirstObjectByType<GameState>(); // Intiailize game state reference
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameState.Lose();  // Call lose function when health drops below or equal to 0
        }
    }
}
