using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject fire;
    [SerializeField] Transform projectileLocation;
    public float projectileSpeed = 20;
    public float timeBetweenAttack = 2;
    private float timeCount;
    public float maxHealth = 30;
    private float currentHealth;
    public SnakeHealth healthBar;
    public GameObject player;
    public GameObject finalScene;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = timeBetweenAttack;
        currentHealth = maxHealth;
        healthBar.SetMax(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        if (timeCount <= 0)
        {
            int type = Random.Range(1, 3);
            if (type == 1)
            {
                StartCoroutine(SpitVenum());
            } else if (type == 2)
            {
                StartCoroutine(FireAttack());
            }
        } else
        {
            StopAnimation();
        }
        
        if (currentHealth == 0)
        {
            finalScene.SetActive(true);
            Destroy(gameObject);
        }
    }

    IEnumerator SpitVenum()
    {
        AttackAnimation();
        yield return new WaitForSeconds(0.2f);
        if (timeCount <= 0)
        {
            GameObject bullet = Instantiate(projectile, projectileLocation.position, projectileLocation.rotation);
            GameObject bullet1 = Instantiate(projectile, projectileLocation.position, projectileLocation.rotation);
            GameObject bullet2 = Instantiate(projectile, projectileLocation.position, projectileLocation.rotation);
            GameObject bullet3 = Instantiate(projectile, projectileLocation.position, projectileLocation.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -0.1f, 0) * Random.Range(5f, projectileSpeed), ForceMode.Impulse);
            bullet1.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -0.1f, 0) * Random.Range(5f, projectileSpeed), ForceMode.Impulse);
            bullet2.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -0.1f, 0) * Random.Range(5f, projectileSpeed), ForceMode.Impulse);
            bullet3.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -0.1f, 0) * Random.Range(5f, projectileSpeed), ForceMode.Impulse);
            timeCount = timeBetweenAttack;
        }

        //animator.SetBool("Attack", false);
    }

    IEnumerator FireAttack()
    {
        AttackAnimation();
        yield return new WaitForSeconds(0.2f);
        if (timeCount <= 0)
        {
            GameObject bullet = Instantiate(fire, projectileLocation.position, projectileLocation.rotation);
            GameObject bullet1 = Instantiate(fire, projectileLocation.position, projectileLocation.rotation);
            bullet.GetComponent<SnakeFireProjectile>().SetPlayer(player);
            bullet1.GetComponent<SnakeFireProjectile>().SetPlayer(player);
            //bullet.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -0.1f, 0) * Random.Range(5f, projectileSpeed), ForceMode.Impulse);
            timeCount = timeBetweenAttack;
        }
        //animator.SetBool("Attack", false);
    }

    IEnumerator SpitFire()
    {
        AttackAnimation();
        yield return new WaitForSeconds(0.2f);
        GameObject bullet = Instantiate(fire, projectileLocation.position, projectileLocation.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(new Vector3(-1, -0.1f, 0) * Random.Range(5f, projectileSpeed), ForceMode.Impulse);
    }

    public void TakeDamage()
    {
        currentHealth--;
        healthBar.SetHealth(currentHealth);
    }

    void AttackAnimation()
    {
        animator.SetBool("Attack", true);
        animator.SetBool("Walk", false);
    }

    void StopAnimation()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", false);
    }

    void WalkAnimation()
    {
        animator.SetBool("Walk", true);
        animator.SetBool("Attack", false);
    }


}
