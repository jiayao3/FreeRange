using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public float speed;
    public float jump;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject doubleJumpEffect;
    private Animator animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask enemy;
    public float gravity;
    float horizontal = 0;
    float face = 1;
    int jumpCount = 0;
    public float projectileSpeed;
    private Vector3 direction;
    private Vector3 hitNormal;
    public GameObject attackHitBox;
    public GameObject attackEffectLeft;
    public GameObject attackEffectRight;
    public Vector3 lastCheckPos;
    public bool respawn = false;
    public bool dontFall = false;
    public float attackDelay = 0.5f;
    private float attackCount = 0;
    private bool attack = true;
    private bool grounded = false;
    private bool sliding = false;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource attackSound;
    [SerializeField] AudioSource pickUpSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Animation();
        if (!attack)
        {
            attackCount -= Time.deltaTime;
        }
        
        if (attackCount <= 0)
        {
            attack = true;
        }
    }

    private void Movement()
    {
        if (SlideDown())
        {
            if (sliding)
            {
                direction.x += (1f - hitNormal.y) * hitNormal.x * (1f);
                sliding = false;
            } else
            {
                hitNormal = Vector3.zero;
            }
        }

        if (respawn == false)
        {
            controller.Move(direction * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if (IsGrounded())
            {
                jumpCount = 0;
                if (grounded)
                {
                    direction.y = 0;
                    grounded = false;
                }
            } else
            {
                direction.y -= gravity * Time.deltaTime;
                grounded = true;
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
                    
                    if (jumpCount < 2)
                    {
                        Instantiate(doubleJumpEffect, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
                        jumpSound.Play();
                        direction.y = jump;
                    }
                    jumpCount++;
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
        } else
        {
            transform.position = lastCheckPos;
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
        if (collision.gameObject.tag == "Egg")
        {
            PlayerChange.NewEgg();
            Destroy(collision.gameObject);
            pickUpSound.Play();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
        sliding = true;
        //Debug.Log(Vector3.Angle(Vector3.up, hitNormal));
    }

    private bool IsGrounded()
    {
        return (Physics.CheckSphere(groundCheck.position, 0.7f, ground) || Physics.CheckSphere(groundCheck.position, 0.7f, enemy));
            //&& (Physics.CheckSphere(groundCheck.position, 0.5f, ground) || Physics.CheckSphere(groundCheck.position, 0.5f, enemy));
    }

    private bool IsSlideDetect()
    {
        return (Physics.CheckSphere(groundCheck.position, 1.3f, ground) || Physics.CheckSphere(groundCheck.position, 1.3f, enemy));
        //&& (Physics.CheckSphere(groundCheck.position, 0.5f, ground) || Physics.CheckSphere(groundCheck.position, 0.5f, enemy));
    }


    private bool SlideDown()
    {
        return (Vector3.Angle(Vector3.up, hitNormal) >= 55 && IsSlideDetect());

    }

    public float GetFace()
    {
        return face;
    }

    public void KnockBack()
    {
        direction.x = -face * 150;
        direction.y = 5;
    }

    public void Attack()
    {
        if (attack)
        {
            attackSound.Play();
            if (PlayerChange.eggActivated == 4)
            {
                GameObject bullet = Instantiate(projectile, transform.position + new Vector3(0, 3, 0), transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(new Vector3(face * projectileSpeed, 0, 0), ForceMode.VelocityChange);
            }
            else
            {
                attackHitBox.SetActive(true);
                if (face == 1)
                {
                    GameObject effect = Instantiate(attackEffectRight, transform.position, attackEffectRight.transform.rotation);
                    //effect.transform.SetParent(transform);
                }
                else if (face == -1)
                {
                    GameObject effect = Instantiate(attackEffectLeft, transform.position, attackEffectLeft.transform.rotation);
                    //effect.transform.SetParent(transform);
                }
                StartCoroutine(DelayAction(0.5f));
            }
            attack = false;
            attackCount = attackDelay;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastCheckPos = other.transform.position;
            respawn = false;

        }
        else if (other.gameObject.tag == "WaterRespawn")
        {
            Debug.Log("respawn");
            respawn = true;
        }

    }
    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        attackHitBox.SetActive(false);
    }
}
