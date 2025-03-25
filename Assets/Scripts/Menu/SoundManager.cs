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
        AudioListener.volume = volumeSlider.value; // You might want to have this reflect only music volume if you're separating them.
        Save();
    }

    public void ChangeSoundEffectsVolume()
    {
        // Assuming you have a method to update sound effects volume
        // For example, you could call a method on an audio source that handles sound effects.
        //source.PlayOneShot(Walk, soundEffectsSlider.value);
        //source.PlayOneShot(Run, soundEffectsSlider.value);
        //source.PlayOneShot(Swing, soundEffectsSlider.value);
        //source.PlayOneShot(Walk, soundEffectsSlider.value);
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
