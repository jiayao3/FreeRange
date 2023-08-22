using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Main Player" || collision.gameObject.tag == "Player")
        {
            
            if (collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().TakeDamage();
            }
        }
        if (collision.gameObject.tag != "Shooter")
        {
            Destroy(gameObject);
        }
        

    }
}
