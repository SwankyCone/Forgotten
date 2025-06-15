using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool isOpened;

    Camera LockCam;
    public GameObject lockCam;
    public GameObject oldCam;
    public GameObject lockBase;

    [SerializeField] InventoryManager.AllItems _itemType;
    [SerializeField] AudioManager audioManager;
    [SerializeField] TMP_Text closeItemText;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        result = new int[] { 0, 0, 0, 0 };
        correctCombination = new int[] { 5, 3, 4, 8 };
        isOpened = false;
        Rotate.Rotated += CheckResults;
        //closeLock();
       
    }

    public void closeLock()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            oldCam.SetActive(true);
            lockCam.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
      
    }


    public void Interact()
    {

        oldCam.SetActive(false);

    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "WheelOne":
                result[0] = number;
                break;

            case "WheelTwo":
                result[1] = number;
                break;

            case "WheelThree":
                result[2] = number;
                break;

            case "WheelFour":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
&& result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isOpened)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
            isOpened = true;
            //Debug.Log("wrwr");

            oldCam.SetActive(true);
            lockCam.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.Locked;
            //Destroy(transform);
            lockBase.SetActive(false);
            InventoryManager.Instance.AddItem(_itemType);
            audioManager.source.PlayOneShot(audioManager.lockUnlock);
            closeItemText.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}