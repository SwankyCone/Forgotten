using System.Collections;
using TMPro;
using UnityEngine;

public class DiaryInspect : MonoBehaviour, IInteractable
{
    [Header("Camera + Player")]
    public GameObject previousCam;
    public GameObject nextCam;
    public GameObject playerController;
    public GameObject particle;

    [Header("UI")]
    [SerializeField] TMP_Text closeItemText;
    [SerializeField] TMP_Text instructions;

    [Header("Diary Pages")]
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;


    private int currentPage = 1;
    private bool itemActive = false;
    private bool playerCanMove = true;

    public void Interact()
    {
        if (!itemActive && playerCanMove)
        {
            itemActive = true;
            playerCanMove = false;

            previousCam.SetActive(false);
            nextCam.SetActive(true);
            playerController.SetActive(false);
            particle.SetActive(false);

            closeItemText.text = "[ Space To Close ]";
            closeItemText.gameObject.SetActive(true);

            instructions.text = "[ Q / E To Turn Page ]";
            instructions.gameObject.SetActive(true);
            // Start on page 1
            ShowPage(1);
        }
    }

    void Update()
    {
        if (itemActive && !playerCanMove)
        {
            // Close the diary
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CloseDiary();
            }

            // Next page
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangePage(1);
            }

            // Previous page
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangePage(-1);
            }
        }
    }

    private void ChangePage(int direction)
    {
        currentPage += direction;

        // Clamp between 1–3
        currentPage = Mathf.Clamp(currentPage, 1, 4);

        ShowPage(currentPage);
    }

    private void ShowPage(int pageNumber)
    {
        page1.SetActive(pageNumber == 1);
        page2.SetActive(pageNumber == 2);
        page3.SetActive(pageNumber == 3);
        page4.SetActive(pageNumber == 4);
    }

    private void CloseDiary()
    {
        itemActive = false;
        playerCanMove = true;

        nextCam.SetActive(false);
        previousCam.SetActive(true);
        playerController.SetActive(true);
        particle.SetActive(true);
        closeItemText.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
    }
}
