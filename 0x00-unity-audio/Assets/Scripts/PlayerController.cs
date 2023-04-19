using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject magicDoor;
    Animator animator;
    private Transform resetSpawn;
    public GameObject teleportSpawnPoint;
    public CharacterController controller;
    public Transform cam;

	public GameObject endGameContainer;
	public int orbs = 0;
	private int health = 5;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float fallingTimeThreshold = 2.5f;
    private int groundCheckProtectionFrames = 0;
    Coroutine fallingTime;
    Coroutine splattingTime;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isFalling;

    public float turnSmoothTime = 0.1f;
    float  turnSmoothVelocity;
    private AudioSource footsteps_Grass;
    private AudioSource footsteps_Rock;


    private void Start() 
    {
        //grabs animator from model
        animator = GameObject.Find("ty").GetComponent<Animator>(); //grabs animator component for access to its parameters(bools, in this case)
        //grabs audio sources for sound
        footsteps_Grass = GameObject.Find("footsteps_running_grass").GetComponent<AudioSource>();
        footsteps_Rock = GameObject.Find("footsteps_running_rock").GetComponent<AudioSource>();
    }


    private void Update()
    {

        //grounded checks if player has no protection frames (protection frames given upon jumping)
        if (groundCheckProtectionFrames <= 0)
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        else
            groundCheckProtectionFrames--;
        if (isGrounded)
        {
            if (animator.GetBool("isFalling") == true) //impact from falling
            {
                animator.SetBool("isSplatting", true);
                GameObject.Find("ty").GetComponent<AnimationTriggers>().splatAndGettingUp();
                //splattingTime = StartCoroutine(splatTime);
            }
            animator.SetBool("isFalling", false); //if grounded, no longer falling
            
            try
            {
                //if grounded, stop falling coroutine
                StopCoroutine(fallingTime);
                Debug.Log("coroutine stopped");
                fallingTime = null;
            }
            catch
            {
            }
            if (velocity.y < 2.0f)
            {
                //normalizes velocity for gravity
                animator.SetBool("isJumping", false);
                velocity.y = -2.0f;
            }
        }
        else if (groundCheckProtectionFrames == 0) //if not grounded but has frames, must have fallen (without jumping)
        {
            if (fallingTime == null) //start falling coroutine if one is not already running
                fallingTime = StartCoroutine(fallTime());
            //sets animation bools
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", false);
            Debug.Log("Fall off");
        }
        
        
        velocity.y += gravity * Time.deltaTime; //apply gravity

        controller.Move(velocity * Time.deltaTime); //move character controller for gravity

        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)//jump
        {
            isGrounded = false;
            //animator params
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", false);
            if (fallingTime != null) //checks if falling coroutine is running, if so, stops it
            {
                StopCoroutine(fallingTime);
                fallingTime = null;
            }
            fallingTime = StartCoroutine(fallTime()); //starts new falling coroutine
            groundCheckProtectionFrames = 8; //adds frames to buffer player before doing grounded check again
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //apply jump physics
        }


        // movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.01f)//if moving
        {
            if (isGrounded) //walking
            {
                
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalking", true);
            }
            //look direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //new direction
            controller.Move(moveDir.normalized * speed * Time.deltaTime); //apply move to character controller
        }
        else //if not moving
        {
            if (isGrounded) //set idle
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true);
            }   
        }
    }

    private void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.CompareTag("Reset")) //Teleport/respawn
        {
            resetSpawn = other.GetComponent<Reset>().teleportSpawnPoint.transform;
            controller.enabled = false;
            GameObject.Find("ty").GetComponent<Animator>().SetBool("isJumping", false);
            GameObject.Find("ty").GetComponent<Animator>().SetBool("isFalling", false);
            GameObject.Find("ty").GetComponent<Animator>().SetBool("isWalking", false);
            player.transform.position = teleportSpawnPoint.transform.position;
            GameObject.Find("ty").GetComponent<Animator>().SetBool("isSplatting", true);
            controller.enabled = true;
            Debug.Log("Reset");
        }
        else if (other.gameObject.CompareTag("Orb")) //orb pickup
        {
            orbs++;
            other.gameObject.SetActive(false);
            if (orbs == 20)
            {
                GameObject.Find("Exit Door").GetComponent<OpenDoor>().opening = true;
            }
        }
        else if (other.gameObject.CompareTag("Trap")) //hit trap
        {
            health--;


        }
    }
    IEnumerator fallTime() //for count to determine if falling
    {
        
        yield return new WaitForSeconds(fallingTimeThreshold);
        animator.SetBool("isFalling", true);
        Debug.Log("Coroutine started");

    }
    IEnumerator splatTime() //once player splats from falling
    {
        yield return null;
    }

}