using UnityEngine;

public class DMenuAudio : MonoBehaviour
{
    public AudioClip Static;

    public AudioSource source;

    public AudioManager audioManager;

    public bool audiotest = false;

  public void staticaudiofile()
    {

        if (audiotest == true)
        {
            audioManager.source.PlayOneShot(audioManager.Static);
        }

    }

}
