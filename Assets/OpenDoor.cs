using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    Animator DoorOpen;
   
    public void Interact()
    {
        Debug.Log("hll");
        DoorOpen.SetBool("DoorOpen", true);
    }

    public void Update()
    {
        DoorOpen = GetComponent<Animator>();
    }

}
