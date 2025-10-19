using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasDestroyer : MonoBehaviour
{
    public GameObject canvasToDestroy; // Assign your Canvas GameObject here in the Inspector

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event when this script is enabled
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event when this script is disabled
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // This method is called every time a new scene is loaded

        // Check if the canvasToDestroy is assigned and still exists in the hierarchy
        if (canvasToDestroy != null)
        {
            // Destroy the Canvas GameObject
            Destroy(canvasToDestroy);
            Debug.Log("Canvas destroyed upon loading new scene: " + scene.name);
        }
    }
}