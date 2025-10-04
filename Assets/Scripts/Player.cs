using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movement = 5f;
    public float running = 10f;
    public float jumpForce = 700f;
    private Rigidbody rb;
    private Vector3 player_x, player_y, player_z;
    public float numberJumps = 1f;
    public float mouseSensibility = 1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public Transform playerCamera;
    public LayerMask groundMask;
    
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Transform groundCheck;

    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;

    private Vector3 move;
    private float x;
    private float z;
    private bool isRunning;
    private float currentSpeed;

    void Start() // Start is called before the first frame update
    {
        controller = GetComponent<CharacterController>();

        CreateGroundCheck();

        Cursor.lockState = CursorLockMode.Locked;

        if (playerCamera == null)
        {
            playerCamera = Camera.main?.transform;
            if (playerCamera == null) 
            {
                Debug.LogError("No tienes la camara asignada");
            } 
        }

        Rigidbody rb = GetComponent <Rigidbody>();
    }
    
    void Update() // Update is called once per frame
    {
        HandleGroundCheck();
        HandleMouseLook();
        HandleMovement();
        HandleJump();
        HandleGravity();

        controller.Move(move * Time.deltaTime);
    }

    

    void CreateGroundCheck() 
    {
        GameObject groundCheckOb = new GameObject("Groundcheck");
        groundCheckOb.transform.SetParent(transform);
        groundCheckOb.transform.localPosition = new Vector3(0, -controller.height / 2f, 0);
        groundCheck = groundCheckOb.transform;
    }

    void HandleGroundCheck() 
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
    }

    void HandleMouseLook() 
    {
        if (playerCamera == null) return;

        mouseX = Input.GetAxis("Mouse X") * mouseSensibility;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensibility;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement() 
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isRunning ? running : movement;

        move = transform.right * x + transform.forward * z;
        move = Vector3.ClampMagnitude(move, 1f) * currentSpeed;

        move.y = velocity.y;
    }

    void HandleJump() 
    {
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    void HandleGravity() 
    {
        velocity.y += gravity;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null) 
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawSphere(groundCheck.position, groundDistance);
        }
    }

    public bool IsGrounded => isGrounded;
    public bool IsRunning => isRunning;
    public float CurrentSpeed => currentSpeed;
    public Vector3 Velocity => controller.velocity;

    public void ToggleCursorLock() 
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        } 
    }
}