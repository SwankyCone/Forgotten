using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private void Update()
    {
        ManageInput();
    }

    private void ManageInput()
    {
        if (Input.GetMouseButton(0))
            Raycast();
    }

    private void Raycast()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 5);

        if (hit.collider == null)
            return;

        Dial dial = hit.collider.GetComponent<Dial>();

        if (dial == null)
            return;

        dial.Rotate();
    }
}
