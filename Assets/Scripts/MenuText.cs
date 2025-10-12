using UnityEngine;

public class MenuText : MonoBehaviour
{
    private MoveMainMenuCamera camMove;

    void Start()
    {
        camMove = Camera.main.GetComponent<MoveMainMenuCamera>();
    }

    void OnMouseDown()
    {
       camMove.MoveToClock();
    }
}
