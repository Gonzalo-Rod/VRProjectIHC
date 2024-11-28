using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Make sure to include this for working with UI components

public class ChangeSceneOnButtonPress : MonoBehaviour
{
    public string targetSceneName; // The name of the scene to load
    public Button changeSceneButton; // Reference to the button that triggers the scene change

    void Start()
    {
        if (changeSceneButton != null)
        {
            // Add listener to the button to call the ChangeScene method when clicked
            changeSceneButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("Button reference is missing!");
        }
    }

    // Method to change the scene
    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName); // Load the target scene
            Debug.Log($"Loading scene: {targetSceneName}");
        }
        else
        {
            Debug.LogError("Target scene name is not set!");
        }
    }
}
