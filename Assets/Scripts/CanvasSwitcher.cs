using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject firstCanvas; // The first canvas to deactivate
    public GameObject secondCanvas; // The second canvas to activate

    public void SwitchCanvas()
    {
        // Ensure both canvases are assigned
        if (firstCanvas != null && secondCanvas != null)
        {
            // Deactivate the first canvas
            firstCanvas.SetActive(false);

            // Activate the second canvas
            secondCanvas.SetActive(true);

            Debug.Log("Switched from the first canvas to the second canvas.");
        }
        else
        {
            Debug.LogWarning("One or both canvas references are missing!");
        }
    }
}
