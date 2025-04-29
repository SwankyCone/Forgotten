using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIAppear : MonoBehaviour, IInteractable
{

    [SerializeField] private Image customImage;

     

    public void Interact()
    {
        customImage.enabled = true;

        if (Input.GetKey(KeyCode.P))
        {
            customImage.enabled = true;
        }
    }

}
