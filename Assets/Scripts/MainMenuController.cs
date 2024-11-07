using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Adjust to your game scene's name
    }

    public void OpenSettings()
    {
        // Implement your settings menu logic
        Debug.Log("Settings menu opened");
    }

    public void OpenAbout()
    {
        // Implement your about menu logic
        Debug.Log("About menu opened");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
