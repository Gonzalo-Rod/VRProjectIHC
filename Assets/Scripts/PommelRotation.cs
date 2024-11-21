using UnityEngine;
using Oculus.Interaction;

public class PommelRotation : MonoBehaviour
{
    public Animator doorAnimator;          // Reference to the door Animator
    public float rotationLimit = 90f;      // Limit for rotation angle
    public float rotationSpeed = 50f;      // Speed of rotation
    private float currentRotation = 0f;    // Tracks current rotation
    private bool doorOpened = false;

    private void OnGrab()
    {
        // Start rotating the pommel when grabbed
        RotatePommel();
    }

    private void RotatePommel()
    {
        if (doorOpened) return;

        // Limit rotation to the specified limit
        if (currentRotation < rotationLimit)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationStep); // Rotate around the Y-axis
            currentRotation += rotationStep;

            if (currentRotation >= rotationLimit)
            {
                TriggerDoorOpenAnimation();
            }
        }
    }

    private void TriggerDoorOpenAnimation()
    {
        doorOpened = true;
        doorAnimator.SetTrigger("DoorOpen"); // Play the door-opening animation
    }
}
