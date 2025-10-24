using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource player;
    public AudioClip Walk;

    private bool isWalking = false;

    void Update()
    {
        // Start walking sound
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (!isWalking)
            {
                
                player.clip = Walk;
                player.loop = true;
                player.Play();
                isWalking = true;
            }
        }

        // Stop walking sound
        if (Input.GetKeyUp(KeyCode.W))
        {
            player.Stop();
            isWalking = false;
        }


    }
}
