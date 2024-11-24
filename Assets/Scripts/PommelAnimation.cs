using UnityEngine;

public class PommelAnimation : MonoBehaviour
{
    public Animator doorAnimator; // Assign the door's Animator in the Inspector
    public Transform pommel; // Assign the pommel GameObject in the Inspector
    public Collider doorCollider; // Assign the door's Collider in the Inspector
    public float openAngle = 25f; // The angle to trigger the door open animation
    public float closeAngle = 0f; // The angle to trigger the door close animation
    public float angleThreshold = 2f; // Threshold to account for slight inaccuracies
    private bool isDoorOpen = false;

    void Update()
    {
        // Get the current Z rotation of the pommel
        float currentAngle = pommel.localEulerAngles.z;

        // Normalize the angle (ensure it is between 0 and 360)
        if (currentAngle > 180) currentAngle -= 360;

        // Check if the pommel is rotated enough to open the door
        if (!isDoorOpen && Mathf.Abs(currentAngle - openAngle) < angleThreshold)
        {
            OpenDoor();
        }
        // Check if the pommel is back to its initial position to close the door
        else if (isDoorOpen && Mathf.Abs(currentAngle - closeAngle) < angleThreshold)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        doorAnimator.SetTrigger("OpenDoor");
        doorCollider.enabled = false; // Disable the collider to prevent collision
        isDoorOpen = true;
    }

    void CloseDoor()
    {
        doorAnimator.SetTrigger("CloseDoor");
        doorCollider.enabled = true; // Re-enable the collider to block the door
        isDoorOpen = false;
    }
}
