using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertChickenController : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float jump;
    private Animator animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] GameObject attackHitBox;
    [SerializeField] LayerMask ground;
    public float gravity;
    float horizontal = 0;
    float face = 1;
    private Vector3 direction;
    public GameObject attackEffectLeft;
    public GameObject attackEffectRight;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Animation();

    }

    private void Movement()
    {
        controller.Move(direction * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (!IsGrounded())
        {
            direction.y -= gravity * Time.deltaTime;
        }

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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsGrounded())
                {
                    direction.y = jump;
                }
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterRespawn")
        {
            Destroy(gameObject);
        }
    }

    private void Animation()
    {
        if (!IsGrounded())
        {
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
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Egg")
        {
            PlayerChange.NewEgg();
            Destroy(collision.gameObject);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.3f, ground);
    }

    public float GetFace()
    {
        return face;
    }

    public void Attack()
    {
        attackHitBox.SetActive(true);
        if (face == 1)
        {
            GameObject effect = Instantiate(attackEffectRight, transform.position, attackEffectRight.transform.rotation);
            effect.transform.SetParent(transform);
        } else if (face == -1)
        {
            GameObject effect = Instantiate(attackEffectLeft, transform.position, attackEffectLeft.transform.rotation);
            effect.transform.SetParent(transform);
        }
        
        StartCoroutine(DelayAction(0.5f));
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        attackHitBox.SetActive(false);
    }
}
