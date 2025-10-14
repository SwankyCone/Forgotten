using UnityEngine;

public class MoveMainMenuCamera : MonoBehaviour
{
    
    public Transform mainMenuCam;
    public Transform clockCam;
    public GameObject clockcamera;
    public GameObject mainCamera;
   
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

    private Transform cameraPosition;

    void Start()
    {
        cameraPosition = mainMenuCam;
        transform.position = mainMenuCam.position;
        transform.rotation = mainMenuCam.rotation;

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPosition.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraPosition.rotation, Time.deltaTime * rotateSpeed);

    }

    public void MoveToClock()
    {
        //mainCamera.SetActive(false);
        //clockcamera.SetActive(true);
        cameraPosition = clockCam;
        
        

    }

  
}
