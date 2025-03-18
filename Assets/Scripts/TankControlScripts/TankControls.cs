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
    //public bool isGrounded = true;
    //public float jumpTime = 1f;
    //private bool canJump = true;
    public float cooldownTime = 1f ;
    private float nextJumpTime = 0 ;

    private void Update()
    {

        //Controls movement
        movement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        rb = GetComponent<Rigidbody>();

        //float dpadHorizontal = Input.GetAxis("DPadHorizontal"); 
        //float dpadVertical = Input.GetAxis("DPadVertical");

        //movement = dpadVertical * moveSpeed * Time.deltaTime;
        //rotation = dpadHorizontal * rotateSpeed * Time.deltaTime;

        // controls jump cooldown
        if (Time.time > nextJumpTime)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
                nextJumpTime = Time.time + cooldownTime;
            }
            
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
