using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class TankControls : MonoBehaviour
{
    public float moveSpeed;
    public float jogSpeed;
    public float rotateSpeed;
    private float movement;
    private float rotation;
    private float jogging;
    private Rigidbody rb;
    public float jumpForce = 10f;
    //public bool isGrounded = true;
    //public float jumpTime = 1f;
    //private bool canJump = true;
    public float cooldownTime = 1f;
    private float nextJumpTime = 0;
    public bool isWalking = false;
    public bool isCrouching = false;
    public float currentSpeed = 0f;

    private float idleTimer = 0f;
    private float afkThreshold = 5f;
    private bool isAfk = false;

    public AudioSource source;
    public AudioClip Walk;
    public AudioClip Run;
    public AudioClip Swing;
  

    [SerializeField] AudioManager audioManager;

    public Rigidbody controller;
    Animator playerAnimator;

    public bool isInteracting = false;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerAnimator = GetComponent<Animator>();
        controller = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        if (isInteracting == true)
            return;


        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //Controls movement

        bool isJogging = Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(vertical) > 0.1f;
        //float speed = isJogging ? jogSpeed : moveSpeed;
        float baseSpeed = isJogging ? jogSpeed : moveSpeed;

        if (vertical < 0)
        {
            baseSpeed *= 0.5f; // Cut speed in half when moving backward
        }

        movement = vertical * baseSpeed * Time.deltaTime;
        rotation = horizontal * rotateSpeed * Time.deltaTime;
        //jogging = Input.GetKeyDown(KeyCode.LeftShift) * jogging * Time.deltaTime;

        rb = GetComponent<Rigidbody>();

        //float dpadHorizontal = Input.GetAxis("DPadHorizontal"); 
        //float dpadVertical = Input.GetAxis("DPadVertical");

        //movement = dpadVertical * moveSpeed * Time.deltaTime;
        //rotation = dpadHorizontal * rotateSpeed * Time.deltaTime;

        // --- Audio --- \\




        // --- Audio --- \\

        // controls jump cooldown
        if (Time.time > nextJumpTime)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
                nextJumpTime = Time.time + cooldownTime;
            }

        }




        bool isInput = Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f ||
               Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f ||
               Input.anyKey;

        // Reset timer if there's input
        if (isInput)
        {
            idleTimer = 0f;
            isAfk = false;
        }
        else
        {
            idleTimer += Time.deltaTime;
        }

        bool hasMovementInput = Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;
        bool isMovingBackwards = vertical < -0.1f;
        bool isMovingForwards = vertical > 0.1f;

        playerAnimator.SetBool("isWalkingBackwards", isMovingBackwards);
        playerAnimator.SetBool("isWalking", isMovingForwards && !isJogging);

        playerAnimator.SetBool("isInput", hasMovementInput);

        // Update the Animator with the timer
        playerAnimator.SetFloat("afkTime", idleTimer);



        //Animations -------------------------------------------

        // Crouching
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //isCrouching = !isCrouching; // Toggle crouch
        //}

        // Movement speed check
        MonitorSpeed(); // Update currentSpeed

        // Animation logic
        bool walking = Mathf.Abs(vertical) > 0.1f;
        bool crouchWalking = isCrouching && walking;
        bool Jogging = Input.GetKey(KeyCode.LeftShift) && walking;

        playerAnimator.SetBool("isWalking", walking && !isCrouching);
        playerAnimator.SetBool("isCrouching", isCrouching);
        playerAnimator.SetBool("Jogging", isJogging);
        //playerAnimator.SetBool("isCrouchWalking", crouchWalking);

        //Animations -------------------------------------------

        if (Input.GetKeyDown(KeyCode.LeftShift) && walking)
        {
            Jog();
        }

    }

    void Jog()
    {
        //Debug.Log("srhsh");


        jogging = Input.GetAxis("Vertical") * jogSpeed * Time.deltaTime;
    }

    private void MonitorSpeed()
    {
        Vector3 horizontalVelocity = new Vector3(controller.linearVelocity.x, 0, controller.linearVelocity.z);
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

 

}