using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    //public Transform InteractorSource;
    //public float interactCooldown = 1f;
    public float InteractRange = 0.1f;
    //private bool canInteract = true;

    public float cooldownTime = 2f;

    private float nextInteractTime = 0f;

    public bool isInteracting = false;

    //

    private Vector3 boxCenter;
    public Vector3 boxHalfExtents = new Vector3(0.5f, 0.5f, 0.5f);
    private Quaternion boxOrientation;
    //private bool showDebugBox = false;

    //


    private void Update()
    {
        if (Time.time > nextInteractTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f); // Size of the box (adjust as needed)
                Vector3 direction = transform.forward;
                float distance = InteractRange;

                // Cast a box in the direction the player is facing
                if (Physics.BoxCast(transform.position, boxHalfExtents, direction, out RaycastHit hitInfo, transform.rotation, distance))
                {
                    boxCenter = transform.position + direction * (distance * 0.5f);
                    boxOrientation = transform.rotation;
                    //showDebugBox = true;

                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        interactObj.Interact();
                        nextInteractTime = Time.time + cooldownTime;
                        isInteracting = true;
                    }
                }

            }
        }
    }

    //private void OnDrawGizmos()
    // {
    // if (showDebugBox)
    // {
    //Gizmos.color = Color.green;
    //Gizmos.matrix = Matrix4x4.TRS(boxCenter, boxOrientation, Vector3.one);
    // Gizmos.DrawWireCube(Vector3.zero, boxHalfExtents * 2f); // Full extents
    // }
    //}

    
}