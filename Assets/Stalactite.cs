using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    Rigidbody rb;
    public float distance;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Main Player" && other.gameObject.GetComponent<Health>())
        {
            rb.isKinematic = false;
            Object.Destroy(gameObject, 2.7f);
        }
        


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Main Player" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {

            if (collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().TakeDamage();
                
            } else if (collision.gameObject.tag == "Main Player" && !collision.gameObject.GetComponent<Health>())
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }
    }
}

    

   
