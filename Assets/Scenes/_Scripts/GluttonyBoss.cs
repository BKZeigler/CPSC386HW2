using UnityEngine;

public class GluttonyBoss : Boss
{
    public Sprite idleSprite;
    public Sprite attackSprite;
    public new float attackTimer;
    public override float attackInterval { get; set; } = 2f;

    public SpriteRenderer spriteRenderer;

    public Player player;
    public float currentHealth;
    private float maxHealth = 100f;
    public HealthBar healthBar;

    public override string bossName { get; set; } = "Gluttony";
    public override float damage { get; set; } = 10f;



    public override void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    public override void Start()
    {
        base.Start();
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindFirstObjectByType<Player>();

        if (player == null)
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    public override void Attack()
    {
        PlayAttackAnimation();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        if (currentHealth < maxHealth)
        {
            if (currentHealth / maxHealth > 0.4f)
            {
                currentHealth += 10; // regenerate on hit
            }
            else
            {
                currentHealth += 20; // regenerate faster when below 40% hp
            }
        healthBar.UpdateHealthBar(currentHealth, maxHealth); //update visually
        }
    }

    public void PlayAttackAnimation()
    {
        spriteRenderer.sprite = attackSprite;
        Invoke("ResetToIdle", attackTimer);
    }

    public void ResetToIdle()
    {
        spriteRenderer.sprite = idleSprite;
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth); // update health bar when taking damage

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        BossProgress.Instance.BossDefeated(bossName);
        UnityEngine.SceneManagement.SceneManager.LoadScene("WrathBoss");
    }
}
