using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor5 : MonoBehaviour, IInteractable
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
        audioManager.Door4.PlayOneShot(audioManager.doorUnlock);


    }

   

}
