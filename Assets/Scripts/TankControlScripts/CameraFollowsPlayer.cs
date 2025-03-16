using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public Transform player;  
    public float rotationSpeed = 5f;  //rotate speeeeeeeedddddd

    void Update()
    {
        //direction to follow the player
        Vector3 directionToPlayer = player.position - transform.position;

        
        directionToPlayer.y = 0;
        //directionToPlayer.z = 0;

        // Create a target rotation based off of the player current positionn
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // rotates the camera towards the target rotation, focusing on the player
        // must fix later as it doesnt fully follow the player and this is annoying me
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
