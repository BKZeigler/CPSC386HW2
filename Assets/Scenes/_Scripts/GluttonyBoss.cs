using UnityEngine;

public class GluttonyBoss : Boss
{
    public Sprite idleSprite;
    public Sprite attackSprite;
    public float attackTimer;

    public SpriteRenderer spriteRenderer;

    public Player player;

    public override void Start()
    {
        Debug.Log("DERIVED START RUNNING", this);
        base.Start();
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
}
