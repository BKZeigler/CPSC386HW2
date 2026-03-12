using UnityEngine;
using System.Collections;


public class Tick : MonoBehaviour
{
    private static float tickDuration = 3f;
    private static float tickInterval = 1f;

    public static Tick Instance;
    void Awake()
    {
    Instance = this;
    }


    public IEnumerator StartTick(Boss boss, float damage)
    {
        float remaining = tickDuration;
        float interval = tickInterval;

        while (remaining > 0f)
        {
            remaining -= Time.deltaTime;
            interval -= Time.deltaTime;

            if (interval <= 0f)
            {
                interval = tickInterval;
                TickOnce(boss, damage);
            }

            yield return null;
        }
    }


    public IEnumerator StartTick(Player player, float damage)
    {
        float remaining = tickDuration;
        float interval = tickInterval;

        while (remaining > 0f)
        {
            remaining -= Time.deltaTime;
            interval -= Time.deltaTime;

            if (interval <= 0f)
            {
                interval = tickInterval;
                TickOnce(player, damage);
            }

            yield return null;
        }
    }


    public void TickOnce(Player player, float damage)
    {
            player.TakeDamage(damage);
    }

    public void TickOnce(Boss boss, float damage)
    {
            boss.TakeDamage(damage);
            Debug.Log("Boss took " + damage + " damage from burn");
    }
}
