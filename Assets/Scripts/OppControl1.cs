using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OppControl1 : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] targetTransform;
    private int targetPoint;
    private Animator animator;  
    public Transform reSpawnPoint;
    private int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0, count7 = 0, count8 = 0, count9 = 0, count10 = 0;
    private float swayVal = 0.0001f;
    private float animFactor =1.85f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
        agent.destination = targetTransform[targetPoint].position;
        targetPoint = 0;
      
    }
    void Update()
    {       
            agent.destination = targetTransform[targetPoint].position;
            animator.SetFloat("Speed", agent.velocity.magnitude * animFactor);               
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "donutStick")
        {
            animator.SetBool("flatFall", true);
        }
        if (collision.gameObject.tag == "donut")
        {
            animator.SetBool("soccerFalling", true);
        }
        if (collision.gameObject.tag == "rotator")
        {
            agent.transform.position = reSpawnPoint.position;
            targetPoint = 0 ;               
            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;
            count6 = 0;
            count7 = 0;
            count8 = 0;
            count9 = 0;
            count10 = 0;
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "donutStick")
        {
            animator.SetBool("flatFall", false);
        }
        if (collision.gameObject.tag == "donut")
        {
            animator.SetBool("soccerFalling", false);
        }
       
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "node1" && count1 == 0)
        {
            count1++;
            targetPoint = 1;          
        }
        if (collision.gameObject.tag == "node2" && count2 == 0)
        {
            count2++;
            targetPoint = 2;
         
        }
        if (collision.gameObject.tag == "node3" && count3 == 0)
        {
            count3++;
            targetPoint = 3;
          
        }
        if (collision.gameObject.tag == "node4" && count4 == 0)
        {
            count4++;
            targetPoint = 4;
         
        }
        if (collision.gameObject.tag == "node5" && count5 == 0)
        {
            count5++;
            targetPoint = 5;
          
        }
        if (collision.gameObject.tag == "node6" && count6 == 0)
        {
            count6++;
            targetPoint = 6;
           
        }
        if (collision.gameObject.tag == "node7" && count7 == 0)
        {
            count7++;
            targetPoint = 7;
          
        }
        if (collision.gameObject.tag == "node8" && count8 == 0)
        {
            count8++;
            targetPoint = 8;
        }
        if (collision.gameObject.tag == "node9" && count9 == 0)
        {
            count9++;
            targetPoint = 9;
        }
        if (collision.gameObject.tag == "node10" && count10 == 0)
        {
            count10++;
            targetPoint = 10;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {         
            animator.SetBool("salsa", true);
        }
    }
}
