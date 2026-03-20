using UnityEngine;
using System.Collections;


public class Tick : MonoBehaviour
{
    private static float tickDuration = 3f; // duration of the DOT
    private static float tickInterval = 1f; // interval between each tick of damage

    public static Tick Instance; // singleton instance of tick, used to start coroutines for spell effects (burn)
    void Awake()
    {
    Instance = this; // create singleton instance of tick
    }


    public IEnumerator StartTick(Boss boss, float damage) // start DOT on boss
    {
        float remaining = tickDuration; // remaining time for the DOT
        float interval = tickInterval; // interval timer for when to apply damage

        while (remaining > 0f) // while there is still time remaining on the DOT
        {
            remaining -= Time.deltaTime; // reduce remaining time by time since last frame
            interval -= Time.deltaTime; // reduce interval timer by time since last frame

            if (interval <= 0f) // when interval timer hits zero
            {
                interval = tickInterval; // reset interval timer
                TickOnce(boss, damage); // apply damage to boss
            }

            yield return null; // wait until next frame to continue the loop
        }
    }


    public IEnumerator StartTick(Player player, float damage) // player DOT not used yet
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


    public void TickOnce(Player player, float damage) // player tick not used yet
    {
            player.TakeDamage(damage);
    }

    public void TickOnce(Boss boss, float damage) // applies one tick of damage to boss
    {
            boss.TakeDamage(damage);
    }
}
