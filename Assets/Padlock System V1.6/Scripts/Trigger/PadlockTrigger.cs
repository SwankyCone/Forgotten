using UnityEngine;

namespace PadlockSystem
{
    public class PadlockTrigger : MonoBehaviour
    {
        [Header("Padlock Controller Object")]
        [SerializeField] private PadlockController padlockController = null;

        [SerializeField] private const string playerTag = "Player";

        private bool canUse;

        private void Update()
        {
            ShowPadlockInput();
        }

        void ShowPadlockInput()
        {
            if (canUse && Input.GetKeyDown(PLInputManager.instance.triggerInteractKey))
            {
                padlockController.ShowPadlock();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                canUse = true;
                PLUIManager.instance.ShowUIPrompt(canUse);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                canUse = false;
                PLUIManager.instance.ShowUIPrompt(canUse);
            }
        }
    }
}
