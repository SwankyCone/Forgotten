using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDiner : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("hll");
        SceneManager.LoadScene("Diner");
    }


}
