using UnityEngine;

public class MoveMainMenuCamera : MonoBehaviour
{
    [Header("Camera Positions")]
    public Transform mainMenuPos;
    public Transform clockPos;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

    private Transform target;
   

    void Start()
    {
        target = mainMenuPos;
        transform.position = mainMenuPos.position;
        transform.rotation = mainMenuPos.rotation;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotateSpeed);
    }


    public void MoveToClock()
    {
        target = clockPos;
        
    }

  
}
