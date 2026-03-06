using UnityEngine;

public class GluttonyBoss : Boss
{
    public Sprite idleSprite;
    public Sprite attackSprite;
    public float attackTimer;

    public SpriteRenderer spriteRenderer;

    public Player player;
    public float currentHealth;
    private float maxHealth = 100f;
    public HealthBar healthBar;

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
            player.TakeDamage(10);
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
                CancelInvoke("Attack"); //stop any attack script runninh
                gameObject.SetActive(false); // disable boss
            //go to next scene (debug for now)
            Debug.Log("Gluttony Boss Defeated!");
        }
    }
}
