using UnityEngine;
using UnityEngine.UI;

public class CanvasNavigationWithMovement : MonoBehaviour
{
    public Canvas canvas1; // First canvas
    public Canvas canvas2; // Second canvas
    public Canvas canvas3; // Third canvas
    public Canvas canvas4; // Fourth canvas
    public OVRPlayerController playerController; // Reference to OVRPlayerController

    public Button buttonOnCanvas1; // Button on the first canvas
    public Button buttonOnCanvas2; // Button on the second canvas
    public Button buttonOnCanvas3; // Button on the third canvas
    public Button buttonOnCanvas4; // Button on the fourth canvas

    void Start()
    {
        // Ensure only the first canvas is enabled at the start
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
        canvas3.gameObject.SetActive(false);
        canvas4.gameObject.SetActive(false);

        // Disable OVRPlayerController movement initially
        DisableMovement();

        // Add button listeners
        buttonOnCanvas1.onClick.AddListener(() => SwitchCanvas(canvas1, canvas2));
        buttonOnCanvas2.onClick.AddListener(() => SwitchCanvas(canvas2, canvas3));
        buttonOnCanvas3.onClick.AddListener(() => SwitchCanvas(canvas3, canvas4));
        buttonOnCanvas4.onClick.AddListener(() => EnableMovement());
    }

    void SwitchCanvas(Canvas currentCanvas, Canvas nextCanvas)
    {
        currentCanvas.gameObject.SetActive(false);
        nextCanvas.gameObject.SetActive(true);
    }

    void DisableMovement()
    {
        playerController.EnableLinearMovement = false;
        playerController.EnableRotation = false;
    }

    void EnableMovement()
    {
        canvas3.gameObject.SetActive(false); // Optional: Hide the third canvas after enabling movement
        playerController.EnableLinearMovement = true;
        playerController.EnableRotation = true;
    }
}
