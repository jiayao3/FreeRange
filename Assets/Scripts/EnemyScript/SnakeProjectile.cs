using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeProjectile : MonoBehaviour
{

    [SerializeField] GameObject effect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Main Player" || collision.gameObject.tag == "Player")
        {

            if (collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().TakeDamage();
            }
        }
        if (collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "Boss")
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }
}
