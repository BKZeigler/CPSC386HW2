using UnityEngine;

public abstract class Boss : MonoBehaviour // unique bosses will inherit from this class
{

    public virtual float attackInterval { get; set; } // time between attacks
    public virtual float attackTimer { get; set; } // current timer of boss' attack cooldown
    public virtual string bossName { get; set; } // boss name
    public virtual float damage { get; set; } // boss damage

    public virtual void Awake()
    {
    }
    public virtual void Start()
    {
        attackTimer = attackInterval; // timer starts given the attack interval
    }
    public virtual void Update()
    {
       attackTimer -= Time.deltaTime; // every frame reduce attack timer by time since last frame

       if (attackTimer <= 0f) // when the timer is hits zero
        {
            Attack(); // perform attack
            attackTimer = attackInterval; // and restart timer
        } 
    }

    public virtual void Die()
    {
        CancelInvoke("Attack"); //stop any attack script running
        gameObject.SetActive(false); // disable boss
    }

    public abstract void Attack(); // each boss will have a unique attack function that inherits from this

    public abstract void TakeDamage(float damage); // each boss will have a unique take damage function that inherits from this

}
