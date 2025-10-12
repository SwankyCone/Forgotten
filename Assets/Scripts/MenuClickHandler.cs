using UnityEngine;

public class MenuClickHandler : MonoBehaviour
{
    private Camera cam;
    private MoveMainMenuCamera camMove;

    void Start()
    {
        cam = Camera.main;
        camMove = cam.GetComponent<MoveMainMenuCamera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("MenuText"))
                {
                    if (camMove != null)
                        camMove.MoveToClock();
                }
            }
        }
    }
}
