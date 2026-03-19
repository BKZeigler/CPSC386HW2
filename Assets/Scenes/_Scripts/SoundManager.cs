using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!PlayerPrefs.HasKey("Volume")) // if no saved volume, set to 0.75
        {
            PlayerPrefs.SetFloat("Volume", 0.75f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volumeSlider.value; // set volume to slider value
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        AudioListener.volume = volumeSlider.value; // set volume to slider value
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value); // save volume slider value
    }
}
