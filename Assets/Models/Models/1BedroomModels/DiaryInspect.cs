using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diaryinspect : MonoBehaviour, IInteractable
{
    public GameObject previousCam;
    public GameObject nextCam;
    [SerializeField] TMP_Text closeItemText;
    
    //[SerializeField] AudioManager audioManager;
    public bool itemActive = false;
    public bool playerCanMove = true;
    public GameObject playerController;
    public GameObject particle;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    public bool page1Active = true;
    public bool page2Active = false;
    public bool page3Active = false;
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
            
            closeItemText.gameObject.SetActive(true);
            
        }

    }
    void Start()
    {

        if (playerCanMove == false && Input.GetKeyDown(KeyCode.E))
        {
            page1.SetActive(false);
            page2.SetActive(true);
            page2Active = true;

            if (playerCanMove == false && page2Active == true && Input.GetKeyDown(KeyCode.E))
            {
                page2.SetActive(false);
                page3.SetActive(true);
                page3Active = true;

            }
        }




        if (playerCanMove == false && page2Active == true && Input.GetKeyDown(KeyCode.Q))
        {
            page1.SetActive(true);
            page2.SetActive(false);
            page2Active = false;

        }




        if (playerCanMove == false && page3Active == true && Input.GetKeyDown(KeyCode.Q))
        {
            page2.SetActive(true);
            page3.SetActive(false);
            page3Active = false;

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

            

        }

        
  

    }




}
