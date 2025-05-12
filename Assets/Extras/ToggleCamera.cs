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
        

        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        
    }

    public void Reactivatecam()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            oldCam.SetActive(true);
            lockCam.SetActive(false);
        }

    }
}
