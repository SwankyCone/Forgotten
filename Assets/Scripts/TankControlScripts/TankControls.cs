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
    public bool isWalking = false;
    public bool isCrouching = false;
    public float currentSpeed = 0f;
    private Rigidbody controller;
    Animator playerAnimator;

    public void Start()
    {
        playerAnimator = GetComponent<Animator>();
        controller = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
        //Controls movement
        Cursor.lockState = CursorLockMode.Locked;
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


        //Animations

        bool isWalking = currentSpeed > 0;
        playerAnimator.SetBool("idle to walk", isWalking);

        playerAnimator.SetBool("idle to walk", isWalking);

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("hll");
            playerAnimator.SetBool("idle to walk", true);
        }
        else
        {
            playerAnimator.SetBool("idle to walk", false);
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("hll");
            playerAnimator.SetBool("Crouching", true);

        }
        else

        {
            playerAnimator.SetBool("Crouching", false);
        }

       

        //Animations



    }

    private void MonitorSpeed()
    {
        Vector3 horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        currentSpeed = horizontalVelocity.magnitude;
        //Debug.Log("Player Speed: " + currentSpeed);
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

   public void ActivateAnimations()
    {

        


        // Handle walking/running animations
        //playerController.SetBool("idle to walk", isWalking);


        // Handle crouch animations
        

        if (isCrouching)
        {
            playerAnimator.SetBool("Crouching Idle", true);
            playerAnimator.SetBool("Crouch walk", Input.GetKey(KeyCode.W));
        }
        else
        {
            playerAnimator.SetBool("Crouching Idle", false);
            playerAnimator.SetBool("Crouch walk", false);
        }

        

        if (Input.GetKeyDown(KeyCode.C))
        {

            playerAnimator.SetBool("Crouching", true);

        }
        else 
        
        {
            playerAnimator.SetBool("Crouching", false);
        }

        if (isCrouching)
        {
            playerAnimator.SetBool("idle crouch", true);
            playerAnimator.SetBool("Crouch walk", Input.GetKey(KeyCode.W));
        }
        else
        {
            playerAnimator.SetBool("idle crouch", false);
            playerAnimator.SetBool("Crouch walk", false);
        }

    }


}
