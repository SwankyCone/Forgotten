using UnityEngine;

namespace PadlockSystem
{
    [RequireComponent(typeof(Camera))]
    public class PadlockInteractor : MonoBehaviour
    {
        [SerializeField] private float rayDistance = 5;
        
        private PadlockItem padlockItem;
        private Camera Camera;

        void Start()
        {
            if (!TryGetComponent<Camera>(out Camera))
            {
                Debug.LogError("Camera component not found on the GameObject.");
            }
        }

        void Update()
        {
            if (Physics.Raycast(Camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayDistance))
            {
                var padlock = hit.collider.GetComponent<PadlockItem>();
                if (padlock != null)
                {
                    padlockItem = padlock;
                    HighlightCrosshair(true);
                }
                else
                {
                    ClearSelected();
                }
            }
            else
            {
                ClearSelected();
            }

            if (padlockItem != null)
            {
                if (Input.GetKeyDown(PLInputManager.instance.interactKey))
                {
                    padlockItem.ShowPadlock();
                }
            }
        }

        private void ClearSelected()
        {
            if (padlockItem != null)
            {
                HighlightCrosshair(false);
                padlockItem = null;
            }
        }

        void HighlightCrosshair(bool on)
        {
            PLUIManager.instance.HighlightCrosshair(on);
        }
    }
}
