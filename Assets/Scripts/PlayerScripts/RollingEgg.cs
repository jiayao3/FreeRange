using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingEgg : MonoBehaviour
{

    public float speed;
    public float jump;
    float moveVelocity;
    bool ground = true;
    [SerializeField] AudioSource destroySound;
    [SerializeField] GameObject groundCheck;
    Vector3 hitNormal;
    [SerializeField] LayerMask groundLayer;
    public PhysicMaterial slippery;

    void Update()
    {
        groundCheck.transform.position = transform.position - new Vector3(0, 0.4f, 0);

        if (gameObject.GetComponent<ActivePlayer>().active == true)
        {
            //Jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ground && IsGrounded())
                {
                    GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, jump);
                    ground = false;
                }
            }
            moveVelocity = 0;

            //Left Right Movement
            if (Input.GetKey(KeyCode.A))
            {
                moveVelocity = -speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveVelocity = speed;
            }

            GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            ground = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            destroySound.Play();
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterRespawn")
        {
            Destroy(gameObject);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

    private bool IsGrounded()
    {
        return (Physics.CheckSphere(groundCheck.transform.position, 0.2f, groundLayer));
        //&& (Physics.CheckSphere(groundCheck.position, 0.5f, ground) || Physics.CheckSphere(groundCheck.position, 0.5f, enemy));
    }
}
