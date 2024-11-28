using UnityEngine;

public class LeverWithLocalRotation : MonoBehaviour
{
    public Transform lever; // The lever's transform
    public ParticleSystem particleSystem; // The particle system to activate
    public AudioSource audioSource; // The audio source to play
    public float activationThreshold = 10f; // Degrees of rotation to activate particles (e.g., �10 degrees from the initial position)

    private float initialLocalRotationX; // The initial local rotation of the lever in X

    void Start()
    {
        // Save the initial local rotation of the lever
        initialLocalRotationX = lever.localEulerAngles.x;

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    void Update()
    {
        // Get the current local rotation of the lever in X
        float currentLocalRotationX = lever.localEulerAngles.x;

        // Handle the 360-degree wrap-around issue
        if (currentLocalRotationX > 180)
            currentLocalRotationX -= 360;

        // Calculate the rotation difference
        float rotationDifference = Mathf.Abs(currentLocalRotationX - initialLocalRotationX);

        // Check if the rotation exceeds the threshold
        if (rotationDifference >= activationThreshold)
        {
            if (particleSystem != null && !particleSystem.isPlaying)
            {
                particleSystem.Play(); // Activate particles
                Debug.Log("Particles activated!");

                if (audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.Play();
                    Debug.Log("Audio started!");
                }
            }

        }
        else
        {
            if (particleSystem != null && particleSystem.isPlaying)
            {
                particleSystem.Stop(); // Deactivate particles
                Debug.Log("Particles deactivated!");

                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Stop();
                    Debug.Log("Audio stopped!");
                }
            }
        }
    }
}
