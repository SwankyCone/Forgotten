using UnityEngine;
using UnityEngine.UI;
public class AudioLink : MonoBehaviour
{
    Slider slider;
    public bool sfx;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

   void ChangeVolume()
    {
        BrookesAudioManager.instance.AdjustMasterVolume(sfx, slider.value);
    }
}
