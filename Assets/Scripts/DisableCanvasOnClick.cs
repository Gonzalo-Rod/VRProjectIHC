using UnityEngine;
using UnityEngine.UI;

public class DisableCanvasOnClick : MonoBehaviour
{
    public Button targetButton; // Button that will disable the canvas

    void Start()
    {
        if (targetButton != null)
        {
            // Add the listener to the button
            targetButton.onClick.AddListener(DisableCanvas);
        }
    }

    void DisableCanvas()
    {
        // Get the canvas component attached to this button's parent or higher up
        Canvas canvas = targetButton.GetComponentInParent<Canvas>();

        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No Canvas found in parent hierarchy of the button!");
        }
    }
}
