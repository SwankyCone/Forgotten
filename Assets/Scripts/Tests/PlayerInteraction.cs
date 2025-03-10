using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5f; // Interaction distance

    //public LayerMask interactableLayer; // Layer to define interactable objects
    //public KeyCode interactKey = KeyCode.E; // Key to trigger interaction

    private void Update()
    {
        // Check if player presses interact key
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {

        RaycastHit hit;

        Physics.Raycast(transform.position, transform.forward, out hit, interactRange);
        {
            // Check if the hit object has the "Interactable" tag or an interactable component
            if (hit.collider.CompareTag("Interactable"))
            {
                Debug.Log("Interacting with: " + hit.collider.name);
                // Call the interaction method of the object
                hit.collider.GetComponent<InteractableObject>().Interact();
            }
        }

    }
}
