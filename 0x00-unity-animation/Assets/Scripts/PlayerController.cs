using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject magicDoor;
    private Transform resetSpawn;
    public CharacterController controller;
    public Transform cam;

	public GameObject endGameContainer;
	private int orbs = 0;
	private int health = 5;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    public float turnSmoothTime = 0.1f;
    float  turnSmoothVelocity;

    private void Start() 
    {
        
    }


    private void Update()
    {

        //gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        // horizontal movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            //look direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


    }
    private void OnTriggerEnter(Collider other) //Teleport
    {

        if (other.gameObject.CompareTag("Reset"))
        {
            resetSpawn = other.GetComponent<Reset>().teleportSpawnPoint.transform;
            controller.enabled = false;
            player.transform.position = resetSpawn.position;
            controller.enabled = true;
            Debug.Log("Reset");
        }
        else if (other.gameObject.CompareTag("Orb"))
        {
            orbs++;
            other.gameObject.SetActive(false);
            if (orbs == 20)
            {
                GameObject.Find("Exit Door").GetComponent<OpenDoor>().opening = true;
            }
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;


        }
    }



}