using UnityEngine;
using UnityEngine.UI;

namespace PadlockSystem
{
    public class PLUIManager : MonoBehaviour
    {
        public static PLUIManager instance;

        [Header("Crosshair")]
        [SerializeField] private Image crosshair = null;

        [Header("UI Prompt")]
        [SerializeField] private GameObject interactPrompt = null;

        [Header("Should persist?")]
        [SerializeField] private bool persistAcrossScenes = true;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                if (persistAcrossScenes)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            FieldNullCheck();
        }

        public void ShowUIPrompt(bool on)
        {
            interactPrompt.SetActive(on);
        }

        public void DisableCrosshair(bool on)
        {
            crosshair.enabled = !on;
            Cursor.lockState = on ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = on;
        }

        public void HighlightCrosshair(bool on)
        {
            crosshair.color = on ? Color.red : Color.white;
        }

        void FieldNullCheck()
        {
            // Checking each field and logging an error if it is null
            CheckField(crosshair, "Crosshair");
            CheckField(interactPrompt, "InteractPrompt");
        }

        void CheckField(Object field, string fieldName)
        {
            if (field == null)
            {
                Debug.LogError($"FieldNullCheck: {fieldName} is not set in the inspector!");
            }
        }
    }
}
