using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFireProjectile : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] GameObject player;
    [SerializeField] float speed;

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
        
    }

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

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
