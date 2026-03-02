using UnityEngine;

public abstract class Boss : MonoBehaviour // unique bosses will inherit from this class
{

    public float attackInterval = 2f; // time between attacks
    private float attackTimer; // current timer of boss' attack cooldown

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        Debug.Log("BASE START RUNNING", this);
        attackTimer = attackInterval; // timer starts given the attack interval
    }

    // Update is called once per frame
    public virtual void Update()
    {
       attackTimer -= Time.deltaTime;

       if (attackTimer <= 0f) // when the timer is hits zero
        {
            Attack(); // perform attack
            attackTimer = attackInterval; // and restart timer
        } 
    }

    public abstract void Attack(); // each boss will have a unique attack function that inherits from this
}
