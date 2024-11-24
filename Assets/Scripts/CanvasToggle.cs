using UnityEngine;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3; // Reference to the third canvas

    public Button buttonOnCanvas1ToCanvas2; // Button on Canvas1 to go to Canvas2
    public Button buttonOnCanvas1ToCanvas3; // Button on Canvas1 to go to Canvas3
    public Button buttonOnCanvas2ToCanvas1; // Button on Canvas2 to return to Canvas1
    public Button buttonOnCanvas3ToCanvas1; // Button on Canvas3 to return to Canvas1

    void Start()
    {
        // Ensure only canvas1 is enabled initially
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
        canvas3.gameObject.SetActive(false);

        // Add listeners for navigation
        buttonOnCanvas1ToCanvas2.onClick.AddListener(SwitchToCanvas2);
        buttonOnCanvas1ToCanvas3.onClick.AddListener(SwitchToCanvas3);
        buttonOnCanvas2ToCanvas1.onClick.AddListener(SwitchToCanvas1);
        buttonOnCanvas3ToCanvas1.onClick.AddListener(SwitchToCanvas1);
    }

    void SwitchToCanvas2()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
        canvas3.gameObject.SetActive(false);
    }

    void SwitchToCanvas3()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(false);
        canvas3.gameObject.SetActive(true);
    }

    void SwitchToCanvas1()
    {
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
        canvas3.gameObject.SetActive(false);
    }
}
