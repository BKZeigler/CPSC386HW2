using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{
    public Player player; // Reference to the player object
    public GameObject settingsMenu; // manually assign in inspector

    void Start()
    {
        player = FindFirstObjectByType<Player>(); // Find the player in the scene
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (settingsMenu.activeSelf)
            {
                Time.timeScale = 1f; // Unpause the game by setting time scale back to 1
                Debug.Log("Game Unpaused");
                settingsMenu.SetActive(false); // close the settings menu
            }
            else
            {
                Time.timeScale = 0f; // Pause the game by setting time scale to 0
                Debug.Log("Game Paused");
                settingsMenu.SetActive(true); // open the settings menu
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Unpause the game by setting time scale back to 1
        Debug.Log("Game Unpaused");
        settingsMenu.SetActive(false); // close the settings menu
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Returning to Main Menu");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
