using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour
{
    public GameObject canvas;

    public void Scenefade()
    {
        SceneFader.Instance.FadeToScene("Diner");
        Destroy(canvas);
    }

}
