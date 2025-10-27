using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    Animator Cube;
    [SerializeField] AudioManager audioManager;

    public void Start()
    {
        Cube = GetComponent<Animator>();
    }
    public void Interact()
    {
        Debug.Log("hll");
        Cube.SetBool("DoorOpen", true);
        audioManager.Door.PlayOneShot(audioManager.doorUnlock);


    }

   

}
