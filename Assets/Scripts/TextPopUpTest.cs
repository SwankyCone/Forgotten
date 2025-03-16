using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUpTest : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("hello"); 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;



    }
}
