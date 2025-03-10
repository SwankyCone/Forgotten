using UnityEngine;
using static PlayerInteraction;

public class InteractableObject : MonoBehaviour
{
    public void Interact()
    {
        // Define what happens when the player interacts with this object
        Debug.Log("Interacted with ");
        // Example: Open a door or pickup an item
    }
}