using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBedroom : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("hll");
        SceneFader.Instance.FadeToScene("Bedroom");
    }


}
