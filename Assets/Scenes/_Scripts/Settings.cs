using UnityEngine;
using UnityEngine.InputSystem;

public class Settings : MonoBehaviour
{
    public Player player; // Reference to the player object
    public GameObject settingsMenu; // manually assign in inspector

    void Start()
    {
        player = FindFirstObjectByType<Player>(); // Find the player in the scene
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) // escape toggles settings
        {
            if (settingsMenu.activeSelf)
            {
                Time.timeScale = 1f; // Unpause the game by setting time scale back to 1
                settingsMenu.SetActive(false); // close the settings menu
            }
            else
            {
                Time.timeScale = 0f; // Pause the game by setting time scale to 0
                settingsMenu.SetActive(true); // open the settings menu
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Unpause the game by setting time scale back to 1
        settingsMenu.SetActive(false); // close the settings menu
    }

    public void MainMenu() // return to main menu
    {
        Time.timeScale = 1f; // time is normal
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // load main menu scene
    }

    public void makeVisible() // used for settings button
    {
        settingsMenu.SetActive(true); // opens the settings menu
    }
}
