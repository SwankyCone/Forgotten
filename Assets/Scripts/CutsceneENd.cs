using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneENd : MonoBehaviour
{
    public string nextSceneName = "MainScene";
    public float delayBeforeLoad = 2f;

    public void EndCutscene()
    {
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    private System.Collections.IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(nextSceneName);
        
    }
}
