using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{
    public float speed;
    private float distance;
    public float distanceLimit;
    public int face = 1;
    public CharacterController controller;
    public Vector3 direction;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask enemy;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;
    public GameObject player;
    private bool sky = true;
    private Animator animator;
    private void Start()
    {
        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsGrounded())
        {
            sky = false;
            direction.y = 0;
        }
        
        if (sky || !IsGrounded())
        {
            direction.y -= 10;
        }

        if ((!IsGrounded() && !sky) || IsWall())
        {
            if (!IsGrounded())
            {
                sky = true;
            }
            face = -face;
            distance = distanceLimit;
            transform.rotation = Quaternion.LookRotation(new Vector3(face, 0, 0));
            direction.x = face * speed;
        }
        direction.y -= 10;
        distance -= Time.deltaTime;
        if (distance <= 0)
        {
            face = -face;
            distance = distanceLimit;
            transform.rotation = Quaternion.LookRotation(new Vector3(face, 0, 0));
            direction.x = face * speed;
        }
            
        controller.Move(direction * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }


    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.3f, ground);
    }

    private bool IsWall()
    {
        return Physics.CheckSphere(wallCheck.position, 0.1f, ground) || Physics.CheckSphere(wallCheck.position, 0.1f, enemy);
    }
    
}
