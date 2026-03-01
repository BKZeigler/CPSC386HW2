using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GluttonyBoss : Boss
{
    public Sprite idleSprite;
    public Sprite attackSprite;
    public float attackTimer;

    private SpriteRenderer spriteRenderer;

    public override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Attack(Player player)
    {
        Debug.Log("Trying to play animation");
        PlayAttackAnimation();
        if (player != null)
        {
            player.TakeDamage(10);
        }
    }

    public void PlayAttackAnimation()
    {
        Debug.Log("Playing attack animation");
        spriteRenderer.sprite = attackSprite;
        Invoke("ResetToIdle", attackTimer);
    }

    public void ResetToIdle()
    {
        spriteRenderer.sprite = idleSprite;
    }
}
