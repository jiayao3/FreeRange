using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckControl : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float jump;
    public float dive;
    private Animator animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask water;
    public float gravity;
    float horizontal = 0;
    float face = 1;
    private Vector3 direction;
    Rigidbody rb;
    private bool inWater;
    private int waterTimer = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        waterTimer = 0;


    }

    void Update()
    {
        Movement();
        Debug.Log("TEST");

        Animation();

    }

    private void Movement()
    {

        isWater();
        if (isWater())
        {
            waterTimer++;
        }
        else
        {
            waterTimer = 0;
        }

        if (!inWater)
        {
            controller.Move(direction * Time.deltaTime);

            direction.y -= gravity * Time.deltaTime;
        }


        if (inWater)
        {
            controller.Move(direction * Time.deltaTime);
            rb.useGravity = false;
            rb.isKinematic = false;


            //Debug.Log("water");
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (horizontal > 0)
        {
            face = 1;
        }
        else if (horizontal < 0)
        {
            face = -1;
        }

        if (gameObject.GetComponent<ActivePlayer>().active == true)
        {

            horizontal = Input.GetAxis("Horizontal");
            direction.x = horizontal * speed;

            if (horizontal != 0)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(horizontal, 0, 0));
            }

            if (Input.GetKey(KeyCode.Space))
            {

                if (IsGrounded() && !inWater)
                {

                    direction.y = jump;
                }
                if (inWater)
                {
                    direction.y = dive;
                }



            }



        }
        else
        {
            direction.x = 0;
            horizontal = 0;
        }

        if (gameObject.transform.position.z < -0.001f)
        {
            direction.z += 0.001f;
        }
        else if (gameObject.transform.position.z > 0.001f)
        {
            direction.z -= 0.001f;
        }
        else
        {
            direction.z = 0;
        }
    }

    private void Animation()
    {
        if (isWater())
        {
            animator.SetBool("Swim", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
        else if (!IsGrounded())
        {
            //Debug.Log("run");
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);

        }
        else
        {

            animator.SetBool("Run", false);
            if (horizontal != 0)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            PlayerChange.NewEgg();
            Destroy(collision.gameObject);
        } 
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("fish");
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Debug.Log("enter");
        }
    }*/


    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.3f, ground);
    }

    private bool isWater()
    {
        if (Physics.CheckSphere(groundCheck.position, 0.3f, water) && !Input.GetKey(KeyCode.Space))
        {
            if (waterTimer > 200)
            {
                direction.y = 4;
            }

            inWater = true;
        }
        else
        {

            inWater = false;
        }
        return Physics.CheckSphere(groundCheck.position, 0.3f, water);
    }

    public float GetFace()
    {
        return face;
    }



}