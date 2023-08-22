using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    public GameObject effect;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            Instantiate(effect, transform.position, transform.rotation);
            other.GetComponent<SnakeController>().TakeDamage();
        }
    }
}
