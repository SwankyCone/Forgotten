using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    public float interactionDistance = 5f;
    private bool canInteract = true;
    public float interactCoolDown = 1f;

    public void Update()
    {
        if (canInteract) 
        
        {
            RaycastInteract();
        }
        
    }

    public void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }
    public void RaycastInteract()
    {
        // alter so it can detect if the cooldown is a certain number so you can interact 
        if (Input.GetKeyDown(KeyCode.E) && canInteract && interactCoolDown < 0)
        {
            Interact();
        }
    }

    public void Interact()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject.name + "interactable");

            if (hit.collider.CompareTag("interactable"))
            {
                Debug.Log("interact with" + hit.collider.gameObject.name);
                canInteract = false;
                //interactCoolDown++;
                interactCoolDown++;
            }
        }
    }
}