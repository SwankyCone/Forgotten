using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] InventoryManager.AllItems _itemType;
    [SerializeField] AudioManager audioManager;
    [SerializeField] TMP_Text warningText;
    float warningDisplayTime = 3f;
    public GameObject particle;


    public void Interact()
    {
        audioManager.storageKey.PlayOneShot(audioManager.keyGrab);
        //Debug.Log("fff");
        StartCoroutine(ShowWarningText());
        InventoryManager.Instance.AddItem(_itemType);
        particle.SetActive(false);
        //Destroy(gameObject);
        //gameObject.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(_itemType);
            Destroy(gameObject);
        }
    }

    private IEnumerator ShowWarningText() // text pop up
    {
        // change this to change text
        warningText.text = "Key Collected";
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(warningDisplayTime);
        warningText.gameObject.SetActive(false);

    }
}
