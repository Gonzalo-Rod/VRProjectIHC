using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckFiresDestroyAndChangeSceneWithDelay : MonoBehaviour
{
    public string fireParentTag = "FireParents"; // Tag for parent GameObjects
    public GameObject objectToDestroy; // The GameObject to destroy before changing scenes
    public string targetSceneName; // The name of the scene to switch to
    public float delayBeforeSceneChange = 2f; // Delay in seconds before changing scenes

    private bool isObjectDestroyed = false; // Flag to ensure the object is destroyed only once
    private bool isDelayStarted = false; // Flag to ensure the delay starts only once

    void Update()
    {
        // Check if all FireParents' children are deactivated
        if (AreAllFiresExtinguished())
        {
            // Destroy the specified object if it hasn't already been destroyed
            if (!isObjectDestroyed && objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                isObjectDestroyed = true;
                Debug.Log($"{objectToDestroy.name} has been destroyed.");
            }

            // Start the delay and scene change process if not already started
            if (isObjectDestroyed && !isDelayStarted && !string.IsNullOrEmpty(targetSceneName))
            {
                isDelayStarted = true;
                StartCoroutine(DelayedSceneLoad());
            }
        }
    }

    private bool AreAllFiresExtinguished()
    {
        // Find all GameObjects with the FireParents tag
        GameObject[] fireParents = GameObject.FindGameObjectsWithTag(fireParentTag);

        foreach (GameObject parent in fireParents)
        {
            // Check each child of the parent
            foreach (Transform child in parent.transform)
            {
                // If any child is active, return false
                if (child.gameObject.activeSelf)
                {
                    return false;
                }
            }
        }

        // If all children of all FireParents are inactive, return true
        return true;
    }

    private IEnumerator DelayedSceneLoad()
    {
        Debug.Log($"Delay started. Changing scene in {delayBeforeSceneChange} seconds...");
        yield return new WaitForSeconds(delayBeforeSceneChange); // Wait for the specified delay
        SceneManager.LoadScene(targetSceneName); // Load the target scene
        Debug.Log($"Scene changed to: {targetSceneName}");
    }
}
