using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadNextScene : MonoBehaviour
{
    public GameObject canvas;

    public void LoadScene()
    {
        //SceneManager.LoadScene(" Scene 1 ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(canvas);
        //Cursor.visible = false;

    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
