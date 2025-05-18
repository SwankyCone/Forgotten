using UnityEngine;

public class BookInteraction : MonoBehaviour, IInteractable
{
    public GameObject bookPrefab; // Assign your book prefab in the Inspector
    public Transform inspectPoint; // Assign the empty point in front of the camera
   

    private GameObject currentBook;
    public bool activeBook;

    public void Update()
    {
        if (activeBook == true && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
            //bookPrefab.gameObject.SetActive(false);
            currentBook.gameObject.SetActive(false);
            activeBook = false;

        }
    }

    public void Interact()
    {
        Debug.Log("whiteboard");
        if (activeBook == false)
        {
            ShowBook();
            activeBook = true;
            //closeBook();
        }

        

    }

  
    void ShowBook()
    {
        currentBook = Instantiate(bookPrefab, inspectPoint.position, inspectPoint.rotation);
        currentBook.transform.SetParent(inspectPoint); // Optional: attach to camera


    }


 
}
