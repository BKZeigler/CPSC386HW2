using UnityEngine;

// Will handle most UI buttons

public class MainMenu : MonoBehaviour // stores UI functions
{
    public void LoadGame() // load first level scene
    {
        if (BossProgress.Instance.IsBossDefeated("Gluttony")) // if first boss defeated
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("WrathBoss"); // load second
        }
        else if (BossProgress.Instance.IsBossDefeated("Wrath")) // if second boss defeated
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EnvyBoss"); // load third
        }
        else // else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GluttonyBoss"); // load first
        }
    }

    public void ExitGame() // exit the application
    {
        Application.Quit();
    }

    public void RestartGame() // load main menu scene
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}