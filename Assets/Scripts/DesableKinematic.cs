using UnityEngine;

public class DisableKinematic : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastPosition;

    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();

        // Store the initial position of the object
        lastPosition = transform.position;

        // If there's no Rigidbody, print a warning
        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody found on this object!");
        }
    }

    void Update()
    {
        // Check if the position has changed
        if (transform.position != lastPosition)
        {
            // Disable isKinematic if the object has moved
            if (rb != null && rb.isKinematic)
            {
                rb.isKinematic = false;
                Debug.Log("isKinematic disabled because the object moved.");
            }

            // Update the last position to the current position
            lastPosition = transform.position;
        }
    }
}
