#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class RemoveMissingScripts : EditorWindow
{
    [MenuItem("Tools/Cleanup/Remove Missing Scripts in Scene")]
    static void RemoveMissingScriptsInScene()
    {
        int totalRemoved = 0;
        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>(true))
        {
            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
            if (removed > 0)
                totalRemoved += removed;
        }

        Debug.Log($"✅ Removed {totalRemoved} missing script components from the open scene.");
    }
}
#endif
