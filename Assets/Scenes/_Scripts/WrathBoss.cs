using UnityEngine;

public class WrathBoss : Boss
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

    public override string bossName { get; set; } = "Wrath";
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
        Debug.Log("Wrath defeated! Progress saved.");
        UnityEngine.SceneManagement.SceneManager.LoadScene("EnvyBoss");
    }
}
