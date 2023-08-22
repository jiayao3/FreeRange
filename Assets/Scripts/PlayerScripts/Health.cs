using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public float invincibleCount = 0;
    public float invincibleTime = 2;
    [SerializeField] GameObject effect;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject chicken;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    private void Update()
    {
        if (invincibleCount >= 0)
        {
            invincibleCount -= Time.deltaTime;
        }
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
        if (invincibleCount <= 0)
        {
            shield.SetActive(false);
            if (chicken != null) {
                chicken.GetComponent<Renderer>().material.SetInteger("_On", 0);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Obstacle")
        {
            TakeDamage();
        } else if (collision.gameObject.tag == "Heal")
        {
            if (health < 5)
            {
                AddHealth();
            }
            
            Destroy(collision.gameObject);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            TakeDamage();
        }
    }




    public int GetHealth()
    {
        return health;
    }


    public void TakeDamage()
    {
        if (invincibleCount <= 0)
        {
            health--;
            invincibleCount = invincibleTime;
            GameObject particle = Instantiate(effect, transform.position + new Vector3(0, 1, 0), transform.rotation);
            GetComponent<PlayerController>().KnockBack();
            shield.SetActive(true);
            if (chicken != null) {
                chicken.GetComponent<Renderer>().material.SetInteger("_On", 1);
            }
        }
        
    }

    public void AddHealth()
    {
        health++;
    }
}
