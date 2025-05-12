using UnityEngine;

public class BookInteraction : MonoBehaviour, IInteractable
{
    public GameObject bookPrefab; // Assign your book prefab in the Inspector
    public Transform inspectPoint; // Assign the empty point in front of the camera

    private GameObject currentBook;

    

    public void Interact()
    {

        if (currentBook == null)
        {
            ShowBook();

            CloseBook();
            
        }

        


    }
    void ShowBook()
    {
        currentBook = Instantiate(bookPrefab, inspectPoint.position, inspectPoint.rotation);
        currentBook.transform.SetParent(inspectPoint); // Optional: attach to camera
       
    }

    void HideBook()
    {
        Destroy(currentBook);
    }

    public void CloseBook()
    {
        Debug.Log("gasd");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HideBook();
        }
    }
}
