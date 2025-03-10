using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    private float movement;
    private float rotation;
    private Rigidbody rb;
    public float jumpForce = 10f;
    public bool isGrounded = true;


    private void Update()
    {

        
        movement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        rb = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            
        }
        
        
    }

    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * movement);
        transform.Rotate(0f, rotation, 0f);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   


}
