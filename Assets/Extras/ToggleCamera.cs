using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour, IInteractable
{
    Camera LockCam;
    public GameObject toggledCameraCam;
    public GameObject oldCam;
    public bool lockCamActive = false;


    public void Interact()
    {
       
        //Instantiate(LockCam);
        oldCam.SetActive(false);
        toggledCameraCam.SetActive(true);
        lockCamActive = true;

        Debug.Log("Interact");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ddas");
        }
        

    }

    public void Update()
    {
        if (lockCamActive == true && Input.GetKeyDown(KeyCode.Space))
        {
            oldCam.SetActive(true);
            toggledCameraCam.SetActive(false);
            lockCamActive = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

  

   
   
}