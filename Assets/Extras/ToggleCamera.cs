using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour, IInteractable
{
    Camera LockCam;
    public GameObject lockCam;
    public GameObject oldCam;


    public void Interact()
    {

        //Instantiate(LockCam);
        oldCam.SetActive(false);
        lockCam.SetActive(true);

        Debug.Log("Interact");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

   
   
}