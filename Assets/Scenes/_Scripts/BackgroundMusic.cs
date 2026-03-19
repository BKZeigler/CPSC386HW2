using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // background music should not reset
        }
        else
        {
            Destroy(gameObject); // Only one instance of background music should exist
        }

    }
}
