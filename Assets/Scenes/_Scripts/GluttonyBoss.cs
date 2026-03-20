using UnityEngine;

public class GluttonyBoss : Boss
{
    public Sprite idleSprite; // store idle sprite
    public Sprite attackSprite; // store attack sprite
    public new float attackTimer; // store attack timer
    public override float attackInterval { get; set; } = 2f; // store attack interval

    public SpriteRenderer spriteRenderer; // store sprite renderer

    public Player player; // store player reference
    public float currentHealth; // store current hp
    private float maxHealth = 100f; // store max hp
    public HealthBar healthBar; // stores health bar reference

    public override string bossName { get; set; } = "Gluttony"; // store name
    public override float damage { get; set; } = 10f; // store damage



    public override void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // set hp bar
    }

    public override void Start()
    {
        base.Start(); // call start from base
        currentHealth = maxHealth; // start at full hp
        spriteRenderer = GetComponent<SpriteRenderer>(); // set the renderer
        player = FindFirstObjectByType<Player>(); // set the player

        if (player == null) // if player does not exist
        {
            Debug.LogError("Player not found in the scene."); // error
        }
    }

    public override void Attack() // called every interval
    {
        PlayAttackAnimation(); // play the attack animation
        if (player != null) // if player exists
        {
            player.TakeDamage(damage); // deal dmg to player
        }
        if (currentHealth < maxHealth) // signature mechanic is regen hp
        {
            if (currentHealth / maxHealth > 0.4f) // if above 40% hp
            {
                currentHealth += 10; // regenerate on hit
            }
            else // if below 40% hp
            {
                currentHealth += 20; // regenerate faster when below 40% hp
            }
        healthBar.UpdateHealthBar(currentHealth, maxHealth); //update visually
        }
    }

    public void PlayAttackAnimation() // called during attack
    {
        spriteRenderer.sprite = attackSprite; // switch to attack sprite
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

    public override void Die() // called when hp is 0 or below
    {
        base.Die(); // call die from base
        BossProgress.Instance.BossDefeated(bossName); // mark boss as defeated
        UnityEngine.SceneManagement.SceneManager.LoadScene("WrathBoss"); // load next boss scene
    }
}
