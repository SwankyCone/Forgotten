using UnityEngine;
using UnityEngine.UI;

public class ToggleCanvas : MonoBehaviour
{
   // public Transform Canvas;
    public GameObject Canvas;
    public GameObject Text;
    private MoveMainMenuCamera camMove;
    // public bool Canvass = false;

    private void Start()
    {
        camMove = Camera.main.GetComponent<MoveMainMenuCamera>();
    }
    public void ToggleCanva()
    
    {
        Debug.Log("asf");
       // Canvas.SetActive(true);

    }

    public void OnMouseDown()
    {
        camMove.MoveToClock();

        Canvas.SetActive(true);
        Destroy(Text);
    }
}
