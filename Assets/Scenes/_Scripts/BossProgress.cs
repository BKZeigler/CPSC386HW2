using UnityEngine;

public class BossProgress : MonoBehaviour
{

    public static BossProgress Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // boss progress should not reset
        }
        else
        {
            Destroy(gameObject); // Only one instance of boss progress should exist
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossDefeated(string bossName)
    {
        PlayerPrefs.SetInt(bossName + "Defeated", 1);
        PlayerPrefs.Save();
    }

    public void ClearProgress()
    {
        PlayerPrefs.SetInt("GluttonyDefeated", 0);
        PlayerPrefs.SetInt("WrathDefeated", 0);
        PlayerPrefs.SetInt("EnvyDefeated", 0);
        PlayerPrefs.Save();
    }

    public bool IsBossDefeated(string bossName)
    {
        return PlayerPrefs.GetInt(bossName + "Defeated", 0) == 1; // boss is defeated if value is 1
    }
}
