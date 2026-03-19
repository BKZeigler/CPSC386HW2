using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private Slider volumeSlider;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (!PlayerPrefs.HasKey("Volume"))
            PlayerPrefs.SetFloat("Volume", 0.75f);

        AudioListener.volume = PlayerPrefs.GetFloat("Volume");

        SceneManager.sceneLoaded += OnSceneLoaded;

        AssignSliderInScene();
    }


    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignSliderInScene();
    }

    public void AssignSliderInScene()
    {
        volumeSlider = null;

        // Find ALL sliders, including inactive ones
        Slider[] allSliders = Resources.FindObjectsOfTypeAll<Slider>();

        foreach (Slider s in allSliders)
        {
            // Skip prefab assets (they have no valid scene)
            if (!s.gameObject.scene.IsValid())
                continue;

            // Skip objects not in the active scene
            if (s.gameObject.scene != SceneManager.GetActiveScene())
                continue;

            // Must have the correct tag
            if (!s.CompareTag("VolumeSlider"))
                continue;

            // This is the correct slider
            volumeSlider = s;
            break;
        }

        if (volumeSlider == null)
            return;

        float saved = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = saved;

        volumeSlider.onValueChanged.RemoveAllListeners();
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}



// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class SoundManager : MonoBehaviour
// {
//     [SerializeField] Slider volumeSlider;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         SceneManager.sceneLoaded += OnSceneLoad; // Listen for scene load events
//         if(!PlayerPrefs.HasKey("Volume")) // if no saved volume, set to 0.75
//         {
//             PlayerPrefs.SetFloat("Volume", 0.75f);
//             Load();
//         }
//         else
//         {
//             Load();
//         }
//     }

//     public void SetVolume(float volume)
//     {
//         AudioListener.volume = volumeSlider.value; // set volume to slider value
//         Save();
//     }

//     private void Load()
//     {
//         volumeSlider.value = PlayerPrefs.GetFloat("Volume");
//         AudioListener.volume = volumeSlider.value; // set volume to slider value
//     }

//     private void Save()
//     {
//         PlayerPrefs.SetFloat("Volume", volumeSlider.value); // save volume slider value
//     }

//     void OnDestroy()
//     {
//         SceneManager.sceneLoaded -= OnSceneLoad;
//     }

//     private void OnSceneLoad(Scene scene, LoadSceneMode mode)
//     {
//         GameObject sliderObj = GameObject.FindGameObjectWithTag("VolumeSlider");

//         if (sliderObj != null)
//         {
//             Slider newSlider = sliderObj.GetComponent<Slider>();

//             if (newSlider != null)
//             {
//                 volumeSlider = newSlider;

//                 // Sync slider to saved volume
//                 Load();

//                 // Hook up event
//                 volumeSlider.onValueChanged.RemoveAllListeners();
//                 volumeSlider.onValueChanged.AddListener(SetVolume);
//             }
//         }
//     }
// }

