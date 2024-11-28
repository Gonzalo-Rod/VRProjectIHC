using UnityEngine;

public class FireExtinguish : MonoBehaviour
{
    [SerializeField] private GameObject fireGameObject; // Reference to the fire GameObject
    [SerializeField] private float extinguishTime = 3f; // Time in seconds needed to extinguish the fire
    private float timeUnderSmoke = 0f; // Tracks the time the smoke particles have been colliding

    private void OnParticleCollision(GameObject other)
    {
        // Check if the object colliding with the fire is the smoke particles
        if (other.CompareTag("Smoke"))
        {
            timeUnderSmoke += Time.deltaTime; // Increment time under smoke
            Debug.Log($"Time under smoke: {timeUnderSmoke} / {extinguishTime}");

            if (timeUnderSmoke >= extinguishTime)
            {
                Debug.Log("Fire extinguished!");
                fireGameObject.SetActive(false); // Deactivate the fire GameObject
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the timer when the smoke stops hitting the fire
        if (other.CompareTag("Smoke"))
        {
            timeUnderSmoke = 0f;
            Debug.Log("Smoke stopped hitting the fire. Timer reset.");
        }
    }
}
