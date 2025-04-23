using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace PadlockSystem
{
    public class PLDisableManager : MonoBehaviour
    {
        [SerializeField] private CharacterController player = null;
        [SerializeField] private PadlockInteractor mainCameraInteractor = null;

        [Header("Should persist?")]
        [SerializeField] private bool persistAcrossScenes = true;

        public static PLDisableManager instance;

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
        }

        public void DisablePlayer(bool disable)
        {
            if (disable)
            {
                player.enabled = false;
                mainCameraInteractor.enabled = false;
                PLUIManager.instance.DisableCrosshair(true);
            }

            else
            {
                player.enabled = true;
                mainCameraInteractor.enabled = true;
                PLUIManager.instance.DisableCrosshair(false);
            }
        }
    }
}
