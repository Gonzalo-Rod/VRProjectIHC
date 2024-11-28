using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtendedCanvasSwitcher : MonoBehaviour
{
    public GameObject secondCanvas; // The second canvas to deactivate
    public GameObject targetGameObject; // The GameObject to activate when the first button is pressed

    // Method to deactivate the canvas and activate the GameObject
    public void ActivateGameObject()
    {
        if (secondCanvas != null && targetGameObject != null)
        {
            secondCanvas.SetActive(false); // Deactivate the canvas
            targetGameObject.SetActive(true); // Activate the GameObject

            Debug.Log("Second canvas deactivated, target GameObject activated.");
        }
        else
        {
            Debug.LogWarning("Canvas or target GameObject reference is missing!");
        }
    }

    // Method to navigate to another scene
    public void NavigateToScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Load the specified scene
            Debug.Log($"Navigating to scene: {sceneName}");
        }
        else
        {
            Debug.LogWarning("Scene name is empty or null!");
        }
    }
}
