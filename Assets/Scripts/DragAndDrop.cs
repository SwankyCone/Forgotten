using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Camera cam;
    Vector3 pos;
    public bool holding = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            pos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
    }

    private void OnMouseDown()
    {
        holding = true;
    }

    private void OnMouseUp()
    {
        holding = false;
    }
}
