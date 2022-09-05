using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

  
    public LayerMask lmGround;
    public LayerMask lmPool;
    private float groundCheckDistance = 0.1f;
    public bool isFalled;
    public bool isGrounded;
    private float gravity = -9.81f;
    private Vector3 moveDirection;
    private Vector3 velocity;
    public Animator anim;
    private Rigidbody rb;
    private Animator cameraAnim,lightAnim;
    public Transform reSpawnPoint;
    public bool isFinished = false;
    public int unsuccessingNumb = 0;
    private float swayVal = 0.004f;
    private float playerSpeed = 0.018f;
    public bool countControl = false;
    public Text failureText ;
    public Text timer;
    private float curTime = 0f;
    private float startingTime =30f;
    public Text gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraAnim = transform.GetChild(1).GetComponent<Animator>();
        lightAnim = GameObject.FindGameObjectWithTag("light").transform.GetComponent<Animator>();
        curTime = startingTime;

    }

    void FixedUpdate()
    {

        Grounded();
        Jump();
        Move();
        ErrorCounter();
        if (!isFinished)
        {
            curTime -= Time.deltaTime;
            timer.text = curTime.ToString("0");
        }
       
        if (curTime <= 0)
        {
            StartCoroutine(Wait()) ;
        }
    }


    IEnumerator Wait()
    {
        curTime = 0;
        gameOver.text = "G A M E O V E R";
        transform.position += moveDirection * 0;
        lightAnim.SetBool("gameover",true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 0.75f, ForceMode.Impulse);
            anim.SetBool("jump", true);
        }

    }

    private void Grounded()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, lmGround);
        isFalled = Physics.CheckSphere(transform.position, groundCheckDistance, lmPool);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            anim.SetBool("jump", false);
        }
        if (!isGrounded)
        {
            anim.SetBool("jump", true);

        }

    }
    private void Move()
    {
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        velocity.y += gravity * Time.deltaTime;

        anim.SetFloat("horizontal", horizontalMove);
        anim.SetFloat("vertical", verticalMove);

        if (isFalled)
        {
            transform.position += moveDirection * 0;
            anim.SetBool("jump",true);
        }
        else
        {
           
            if (isFinished == true)
            {
                transform.position += moveDirection * 0;
            }
            else
            {
                transform.position += moveDirection * playerSpeed;
            }
         
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "rotatingPl")
        {

            transform.position -= new Vector3(swayVal, 0, 0);
        }
        if (collision.gameObject.tag == "rotatingPr")
        {

            transform.position += new Vector3(swayVal, 0, 0);
        }

    }
    private void ErrorCounter()
    {
        if (countControl == true)
        {
            unsuccessingNumb++;
            failureText.text = unsuccessingNumb.ToString();
            countControl = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "donutStick")
        {
            anim.SetBool("fall", true);

        }
        if (collision.gameObject.tag == "donut")
        {
            anim.SetBool("soccerFall", true);

        }
        if (collision.gameObject.tag == "rotator")
        {
            anim.SetBool("flatFall", true);
            transform.position = reSpawnPoint.position;
            unsuccessingNumb++;
        }      

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "donutStick")
        {
            anim.SetBool("fall", false);
        }
        if (collision.gameObject.tag == "donut")
        {
            anim.SetBool("soccerFall", false);

        }
        if (collision.gameObject.tag == "rotator")
        {
            anim.SetBool("flatFall", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            transform.position = reSpawnPoint.position;

        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            countControl = true;
        }
        if (other.gameObject.tag == "Finish")
        {
            anim.SetBool("dance", true);
            isFinished = true;
            cameraAnim.SetBool("finish",true);
        }
    }

}
