using UnityEngine;

public class WrathBoss : Boss
{
    public Sprite idleSprite; // stores idle sprite
    public Sprite attackSprite; // stores attack sprite
    public new float attackTimer; // stores attack timer
    public override float attackInterval { get; set; } = 2f; // stores attack interval

    public SpriteRenderer spriteRenderer; // stores sprite renderer

    public Player player; // stores player reference
    public float currentHealth; // stores current hp
    private float maxHealth = 150f; // stores max hp (high hp because of its mechanic)
    public HealthBar healthBar; // stores health bar reference

    public override string bossName { get; set; } = "Wrath"; // stores name
    public override float damage { get; set; } = 10f; // stores damage

    public override void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // get health bar
    }

    public override void Start()
    {
        base.Start(); // call start from base
        currentHealth = maxHealth; // start at full hp
        spriteRenderer = GetComponent<SpriteRenderer>(); // set renderer
        player = FindFirstObjectByType<Player>(); // set player reference

        if (player == null) // if player does not exist
        {
            Debug.LogError("Player not found in the scene."); // error
        }
    }

    public override void Attack()
    {
        PlayAttackAnimation(); // play the attack animation
        if (player != null) // if player exists
        {
            player.TakeDamage(damage); // deal damage to player
        }
    }

    public void PlayAttackAnimation() // called during the attack
    {
        spriteRenderer.sprite = attackSprite; // change to attack sprite
        Invoke("ResetToIdle", attackTimer); // after the attack timer
    }

    public void ResetToIdle()
    {
        spriteRenderer.sprite = idleSprite; // reset to idle sprite
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage; // reduce hp by damage taken
        healthBar.UpdateHealthBar(currentHealth, maxHealth); // update health bar when taking damage

        if (currentHealth <= 0) // if hp is 0 or below
        {
            Die(); // die
        }
    }

    public override void Die()
    {
        base.Die(); // call die from base
        BossProgress.Instance.BossDefeated(bossName); // mark boss as defeated in boss progress
        UnityEngine.SceneManagement.SceneManager.LoadScene("EnvyBoss"); // load next boss scene
    }
}
