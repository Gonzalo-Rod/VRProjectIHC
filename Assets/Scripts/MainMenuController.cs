using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("HouseScene");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings menu opened");
    }

    public void OpenAbout()
    {
        Debug.Log("About menu opened");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
