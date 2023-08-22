using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : MonoBehaviour
{
    public float speed;
    public float distanceLimit;
    public int face = 1;
    public CharacterController controller;
    public Vector3 direction;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask enemy;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerCheck;
    [SerializeField] GameObject attackHitBox;

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
        if (player.transform.position.x <= gameObject.transform.position.x)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
        } else
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
        }
        if (IsPlayer())
        {
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
        attackHitBox.SetActive(true);
        attackHitBox.SetActive(false);
    }

    private bool IsPlayer()
    {
        return (Physics.CheckSphere(playerCheck.transform.position, 2f, playerLayer));
        //&& (Physics.CheckSphere(groundCheck.position, 0.5f, ground) || Physics.CheckSphere(groundCheck.position, 0.5f, enemy));
    }

    
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

}
