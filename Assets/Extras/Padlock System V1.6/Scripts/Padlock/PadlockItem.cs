using UnityEngine;

namespace PadlockSystem
{
    public class PadlockItem : MonoBehaviour
    {
        [SerializeField] private PadlockController _padlockController = null;

        public void ShowPadlock()
        {
            _padlockController.ShowPadlock();
        }
    }
}
