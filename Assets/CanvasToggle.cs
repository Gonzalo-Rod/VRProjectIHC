using UnityEngine;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    public Button buttonOnCanvas1;
    public Button buttonOnCanvas2;

    void Start()
    {
        // Ensure only one canvas is enabled initially
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);

        // Add listeners to the buttons
        buttonOnCanvas1.onClick.AddListener(SwitchToCanvas2);
        buttonOnCanvas2.onClick.AddListener(SwitchToCanvas1);
    }

    void SwitchToCanvas2()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }

    void SwitchToCanvas1()
    {
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
    }
}
