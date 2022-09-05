using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundMask;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;
    public Animator anim;



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        anim.SetFloat("horizontal", moveX);
        anim.SetFloat("vertical", moveZ);
        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
          
            }

          

            moveDirection *= moveSpeed;
        }



        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetBool("Jump", false);
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetBool("Jump", false);
    }
    private void Idle()
    {
        anim.SetBool("Jump", false);
    }
    private void Jump()
    {
      //  velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
      //  anim.SetBool("Jump",true);
    }
}
