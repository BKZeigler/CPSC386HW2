using UnityEngine;

public abstract class Boss : MonoBehaviour // unique bosses will inherit from this class
{

    public float attackInterval = 2f; // time between attacks
    private float attackTimer = 1f; // current timer of boss' attack cooldown

    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        player = FindFirstObjectByType<Player>();
        attackTimer = attackInterval; // timer starts given the attack interval
    }

    // Update is called once per frame
    public virtual void Update()
    {
       attackTimer -= Time.deltaTime;

       if (attackTimer <= 0f) // when the timer is hits zero
        {
            Attack(null); // perform attack
            attackTimer = attackInterval; // and restart timer
        } 
    }

    public abstract void Attack(Player player); // each boss will have a unique attack function that inherits from this
}
