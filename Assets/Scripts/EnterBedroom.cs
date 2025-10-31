using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBedroomScene : MonoBehaviour, IInteractable
{


    [SerializeField] InventoryManager.AllItems _requiredItem;
    [SerializeField] TMP_Text warningText;
    [SerializeField] AudioManager audioManager;

    Animator Cube;
    float warningDisplayTime = 3f;
    public GameObject canvas;
    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._InventoryItems.Contains(itemRequired))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void Start()
    {
        Cube = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (HasRequiredItem(_requiredItem))
        {
            Cube.SetBool("DoorOpen", true);
            //SceneFader.Instance.FadeToScene("Bedroom");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(canvas);
            //audioManager.source.PlayOneShot(audioManager.doorUnlock);
        }

        else
        {
            StartCoroutine(ShowWarningText());
            audioManager.source3.PlayOneShot(audioManager.doorLocked);
        }
    }

    private IEnumerator ShowWarningText()
    {
        warningText.text = "Its Locked";
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(warningDisplayTime);
        warningText.gameObject.SetActive(false);
    }
}
