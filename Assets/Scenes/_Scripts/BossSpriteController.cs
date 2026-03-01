using UnityEngine;

public class BossSpriteController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Sprite idleSprite;
    private Sprite attackSprite;
    private float attackTime;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void PlayAttackAnimation()
    {
        spriteRenderer.sprite = attackSprite;
        Invoke("ResetToIdle", attackTime);
    }

    public void ResetToIdle()
    {
        spriteRenderer.sprite = idleSprite;
    }
}
