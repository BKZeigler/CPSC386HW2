using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{
    public Player player; // Reference to the player object
    public bool settingsOpen = false;

    void Start()
    {
        player = FindFirstObjectByType<Player>(); // Find the player in the scene
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (settingsOpen)
            {
                Time.timeScale = 1f; // Unpause the game by setting time scale back to 1
                Debug.Log("Game Unpaused");
                settingsOpen = false;
            }
            else
            {
                Time.timeScale = 0f; // Pause the game by setting time scale to 0
                Debug.Log("Game Paused");
                settingsOpen = true;
            }
            // If settings is not open, open it, if open close it and unpause
            // Pause the game
            // Open a settings menu
            //
        }
    }

    public void Lose()
    {
        Debug.Log("Player has lost the game!");
        // Send to lose scene where player can restart quit
    }
}
