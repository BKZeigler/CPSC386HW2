using UnityEngine;
using UnityEngine.InputSystem;

public class EnvyBoss : Boss // inherits from boss
{
    public Sprite idleSprite; // store idle sprite
    public Sprite attackSprite; // store attack sprite
    public new float attackTimer; // store attack timer
    public override float attackInterval { get; set; }  = 2f; // store attack interval

    public SpriteRenderer spriteRenderer; // store sprite renderer

    public Player player; // store player reference
    public float currentHealth; // store current hp
    private float maxHealth = 50f; // store max hp (low hp because of its mechanic)
    public HealthBar healthBar; // stores health bar reference

    public override string bossName { get; set; } = "Envy"; // stores its name
    public override float damage { get; set; } = 5f; // stores its damage (low damage because of its mechanic)

    public override void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // find hp bar
    }

    public override void Start()
    {
        base.Start(); // call start from base class
        currentHealth = maxHealth; // start at full hp
        spriteRenderer = GetComponent<SpriteRenderer>(); // set the renderer
        player = FindFirstObjectByType<Player>(); // set the player

        if (player == null) // if player does not exist
        {
            Debug.LogError("Player not found in the scene."); // error
        }
    }

    public override void Update()
    {
        base.Update(); // call update from base
        if (Keyboard.current.backspaceKey.wasPressedThisFrame) // the signature mechanic happens when backspace pressed
        {
            maxHealth += 25f; // increase max health on player backspace
            currentHealth = maxHealth; // heal to full
            healthBar.UpdateHealthBar(currentHealth, maxHealth); // update health bar visually
            damage = maxHealth / 10f; // increase damage based on max hp
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
        spriteRenderer.sprite = attackSprite; // switch to relevant sprite
        Invoke("ResetToIdle", attackTimer); // then switch back after the timer
    }

    public void ResetToIdle() // called after a timer
    {
        spriteRenderer.sprite = idleSprite; // reset to idle sprite
    }

    public override void TakeDamage(float damage) // called when player damages boss
    {
        currentHealth -= damage; // reduce hp by damage dealt
        healthBar.UpdateHealthBar(currentHealth, maxHealth); // update health bar when taking damage

        if (currentHealth <= 0) // if hp is 0 or below
        {
            Die(); // die
        }
    }

    public override void Die() // called when boss hp is 0 or below
    {
        base.Die(); // call die from base
        BossProgress.Instance.BossDefeated(bossName); // mark boss as defeated
        BossProgress.Instance.ClearProgress(); // after envy is defeated, victory and progress reset
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory"); // load the victory screen as last boss defeated
    }
}
