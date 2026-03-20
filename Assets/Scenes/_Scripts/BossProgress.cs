using UnityEngine;

public class BossProgress : MonoBehaviour // keeps track of what bosses player has beat
{

    public static BossProgress Instance;
    void Awake()
    {
        if(Instance == null) // if progress doesnt exist
        {
            Instance = this; // create it
            DontDestroyOnLoad(gameObject); // boss progress should not reset on scene change
        }
        else // if it already exists
        {
            Destroy(gameObject); // Only one instance of boss progress should exist
        }

    }
    void Start()
    {
    }
    void Update()
    {        
    }

    public void BossDefeated(string bossName) // call this whe a boss is defeated
    {
        PlayerPrefs.SetInt(bossName + "Defeated", 1); // set key to 1 for that boss to say it is defeated
        PlayerPrefs.Save(); // save that data
    }

    public void ClearProgress() // called when game is won so you can play again
    {
        PlayerPrefs.SetInt("GluttonyDefeated", 0); // mark boss 1 as undefeated
        PlayerPrefs.SetInt("WrathDefeated", 0); // mark boss 2 as undefeated
        PlayerPrefs.SetInt("EnvyDefeated", 0); // mark boss 3 as undefeated
        PlayerPrefs.Save(); // save that data
    }

    public bool IsBossDefeated(string bossName) // called when loading the game to check progress
    {
        return PlayerPrefs.GetInt(bossName + "Defeated", 0) == 1; // boss is defeated if value is 1
    }
}
