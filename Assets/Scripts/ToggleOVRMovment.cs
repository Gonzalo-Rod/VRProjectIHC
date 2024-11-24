using UnityEngine;

public class ToggleOVRMovement : MonoBehaviour
{
    public OVRPlayerController playerController; // Reference to the OVRPlayerController
    public Canvas targetCanvas; // Reference to the canvas that toggles movement

    void Update()
    {
        if (targetCanvas != null && playerController != null)
        {
            // Check if the canvas is active
            if (targetCanvas.gameObject.activeSelf)
            {
                DisableMovement();
            }
            else
            {
                EnableMovement();
            }
        }
    }

    void DisableMovement()
    {
        // Disable movement by setting enableMovement to false
        playerController.EnableLinearMovement = false;
        playerController.EnableRotation = false;
    }

    void EnableMovement()
    {
        // Re-enable movement by setting enableMovement to true
        playerController.EnableLinearMovement = true;
        playerController.EnableRotation = true;
    }
}
