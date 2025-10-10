using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlast : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneFader.Instance.FadeToScene("EndOfPlaythrough");
    }


}
