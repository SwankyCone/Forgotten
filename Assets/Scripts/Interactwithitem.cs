using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactwithitem : MonoBehaviour, IInteractable 
{
    public GameObject previousCam;
    public GameObject nextCam;
    [SerializeField] TMP_Text closeItemText;
    [SerializeField] TMP_Text descriptionText;
    //[SerializeField] AudioManager audioManager;
    public bool itemActive = false;
    public bool playerCanMove = true;
    public GameObject playerController;
    public GameObject particle;
    public string[] description;
    public int index;
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

            closeItemText.text = "[ Space To Close ]";
            descriptionText.text = description[index];
            closeItemText.gameObject.SetActive(true);
            descriptionText.gameObject.SetActive(true);
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
            descriptionText.gameObject.SetActive(false);
            //audioManager.paper.PlayOneShot(audioManager.paperGrab);

        }
    }

}
