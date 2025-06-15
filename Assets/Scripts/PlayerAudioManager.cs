using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerAudioManager : MonoBehaviour
{
  
    public AudioSource player;
   

    public AudioClip Walk;
    public AudioClip Run;
   

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W))
        {
            player.PlayOneShot(Walk);
            
        }

        if (Input.GetKeyUp(KeyCode.W))
        {

            player.Stop();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.PlayOneShot(Run);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            player.Stop();
        }

    }
}
