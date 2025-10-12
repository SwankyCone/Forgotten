using UnityEngine;

public class ReturnButton : MonoBehaviour
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
