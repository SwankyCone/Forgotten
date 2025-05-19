using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider soundEffectsSlider;
    //public AudioSource source;
    public AudioClip Walk;
    public AudioClip Run;
    public AudioClip Swing;
    public AudioClip doorLocked;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            PlayerPrefs.SetFloat("soundEffectsVolume", 0.5f);
            Load();
        }

        else
        {
            Load();
        }
    }

   

    public void ChangeMusicVolume()
    {
        AudioListener.volume = volumeSlider.value; 
        Save();
    }

    public void ChangeSoundEffectsVolume()
    {
     
        //source.PlayOneShot(Walk, soundEffectsSlider.value);
        //source.PlayOneShot(Run, soundEffectsSlider.value);
        //source.PlayOneShot(Swing, soundEffectsSlider.value);
        //source.PlayOneShot(Walk, soundEffectsSlider.value);
        AudioListener.volume = soundEffectsSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundEffectsSlider.value = PlayerPrefs.GetFloat("soundEffectsVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsSlider.value);
    }
    public void PlaySoundEffect(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, soundEffectsSlider.value);
    }

}
