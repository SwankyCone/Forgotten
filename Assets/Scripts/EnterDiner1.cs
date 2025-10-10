using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDiner1 : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("hll");
        SceneFader.Instance.FadeToScene("Diner");
    }


}
