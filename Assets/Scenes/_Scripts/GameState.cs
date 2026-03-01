using UnityEngine;

public class GameState : MonoBehaviour
{
    public Player player; // Reference to the player object

    void Start()
    {
        player = FindFirstObjectByType<Player>(); // Find the player in the scene
    }

    void Update()
    {
        // Handle game state updates if needed
    }

    public void Lose()
    {
        Debug.Log("Player has lost the game!");
        // Send to lose scene where player can restart quit
    }
}
