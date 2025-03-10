using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    //public Transform InteractorSource;
    //public float interactCooldown = 1f;
    public float InteractRange;
    //private bool canInteract = true;

    public float cooldownTime = 2;

    private float nextInteractTime = 0;


    private void Update()
    {
        //Debug.Log("Update is being called");

        if (Time.time > nextInteractTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
                //Debug.Log("F key pressed");
                //nextInteractTime = Time.time + cooldownTime;
            {
                Ray r = new Ray(transform.position, transform.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        interactObj.Interact();
                        nextInteractTime = Time.time + cooldownTime;
                        //interactCooldown--;
                    }
                }
            }
        }
    }

    
}
