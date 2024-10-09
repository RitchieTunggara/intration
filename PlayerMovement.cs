using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    private PlayerAnimation playerAnim;

    [SerializeField]
    private bool GameStart;

    private float currentSpeed;

    // float horizontalInput;
    // float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    Vector3 rotationRight = new Vector3(0, 15, 0);
    Vector3 rotationLeft = new Vector3(0, -15, 0);

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);
    public int rotation;

    private void Start()
    {
        rotation = 15;
        if (gameObject.name == "PlayerTandu")
        {
            moveSpeed = 2.5f;
        }
        else
        {
            moveSpeed = 5f;
        }
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        playerAnim = GetComponent<PlayerAnimation>();
        GameStart = false;
    }

    private void Update()
    {
        rotationRight = new Vector3(0, rotation, 0);
        rotationLeft = new Vector3(0, -(rotation), 0);

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        // MyInput();
        SpeedControl();

        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else 
        {
            rb.drag = 0;
        }

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") )
        {
            if (GameStart == true)
            {
                playerAnim.isMove(true);
            }
        }
        else
        {
            playerAnim.isMove(false);
        }
    }

    private void FixedUpdate()
    {
        if (GameStart == true)
        {
            MovePlayer();
        }
    }

    // private void MyInput()
    // {
    //     horizontalInput = Input.GetAxisRaw("Horizontal");
    //     verticalInput = Input.GetAxisRaw("Vertical");
    // }

    private void MovePlayer()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(backward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

        if (Input.GetKey("a"))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }

        // moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        // rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.y);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void StartTheGame()
    {
        GameStart = true;
    }

    public void stopVehicle()
    {
        currentSpeed = moveSpeed;
        moveSpeed = 0;
    }

    public void startVehicle()
    {
        moveSpeed = currentSpeed;
    }
    public void increaseSpeed()
    {
        moveSpeed *= 3;
        rotation *= 3;
    }
}
