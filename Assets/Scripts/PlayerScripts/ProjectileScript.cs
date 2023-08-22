using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Projectile")
        {
            GameObject particle = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
        if (other.gameObject.tag == "Ground")
        {
            GameObject particle = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            GameObject particle = Instantiate(explosion, transform.position, transform.rotation);
            other.GetComponent<SnakeController>().TakeDamage();
            Destroy(gameObject);
        }


    }
}
