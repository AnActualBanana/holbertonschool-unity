using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    private CharacterController controller;
    private bool isGrounded;
    public float groundCheckDistance = 0.1f;
    private float verticalVelocity = 0.0f;

    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    [SerializeField]
    private Camera _followCamera;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    [SerializeField]
    private float jumpHeight = 30.0f;
    [SerializeField]
    private float jumped = 0.00f;
    private bool jumping = false;

    [SerializeField]
    private float _gravityValue = -9.81f;
    public GameObject resetSpawn;

    private void Start() 
    {
        controller = GetComponent<CharacterController>();    
    }

    private void Update() 
    {
        UpdateGroundCheck();
        Movement();    
    }

    private void FixedUpdate() {
        {
            //UpdateGroundCheck();
        }
    }

    void UpdateGroundCheck()
{
    // Cast a ray from player's feet to the ground to check if there is a ground surface
    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, groundCheckDistance))
    {
        isGrounded = true;
    }
    else
    {
        isGrounded = false;
    }
}
    void Movement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;



        Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            
        
        //if (isGrounded == false && jumping == false)
            controller.Move(Physics.gravity/1.5f * Time.deltaTime);

        if (movementDirection != Vector3.zero) 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
            movementDirection *= _playerSpeed;
            controller.Move(movementDirection * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
                StartCoroutine("jump");
        }
        
        }
    IEnumerator jump()
    {
        jumping = true;
        while (jumped < jumpHeight)
        {
            controller.Move(Vector3.up * ((jumped += jumpHeight/60) * 1.5f) * Time.deltaTime);
            yield return null;
        }
        jumping = false;
        jumped = 0;
    yield break;  
    }

    private void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.CompareTag("Reset"))
        {
            controller.enabled = false;
            player.transform.position = resetSpawn.transform.position;
            controller.enabled = true;
            Debug.Log("Reset");
        }
    }
}
