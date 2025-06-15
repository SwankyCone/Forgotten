using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookInteraction : MonoBehaviour, IInteractable
{
    public GameObject bookPrefab; 
    public Transform inspectPoint; 
   

    private GameObject currentBook;
    public bool activeBook;
    [SerializeField] TMP_Text closeItemText;
    [SerializeField] AudioManager audioManager;

    public void Update()
    {
        if (activeBook == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
            //bookPrefab.gameObject.SetActive(false);
            currentBook.gameObject.SetActive(false);
            activeBook = false;
            closeItemText.gameObject.SetActive(false);
            audioManager.paper.PlayOneShot(audioManager.paperGrab);

        }
    }

    public void Interact()
    {
        Debug.Log("whiteboard");
        if (activeBook == false)
        {
            ShowBook();
            activeBook = true;
            audioManager.source.PlayOneShot(audioManager.paperGrab);
            //closeBook();
        }

        

    }

  
    void ShowBook()
    {
        currentBook = Instantiate(bookPrefab, inspectPoint.position, inspectPoint.rotation);
        currentBook.transform.SetParent(inspectPoint);
        closeItemText.text = "Space To Close";
        closeItemText.gameObject.SetActive(true);

    }

  

}
