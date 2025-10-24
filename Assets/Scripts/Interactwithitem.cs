using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactwithitem : MonoBehaviour, IInteractable 
{
    public GameObject previousCam;
    public GameObject nextCam;
    [SerializeField] TMP_Text closeItemText;
    //[SerializeField] AudioManager audioManager;
    public bool itemActive = false;
    public bool playerCanMove = true;
    public GameObject playerController;
    public GameObject particle;
    public void Interact()
    {
        if (itemActive == false && playerCanMove == true) 
        {
            itemActive = true;
            playerCanMove = false;
            previousCam.SetActive(false);
            nextCam.SetActive(true);
            playerController.SetActive(false);
            particle.SetActive(false);

            closeItemText.text = "Space To Close";
            closeItemText.gameObject.SetActive(true);
        }

    }
    public void Update()
    {
        if (itemActive == true && playerCanMove == false && Input.GetKeyDown(KeyCode.Space))
        {
           
            nextCam.SetActive(false);
            previousCam.SetActive(true);
            itemActive = false;
            playerCanMove = true;
            playerController.SetActive(true);
            particle.SetActive(true);
            closeItemText.gameObject.SetActive(false);
            //audioManager.paper.PlayOneShot(audioManager.paperGrab);

        }
    }

}
