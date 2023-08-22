using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{

    public GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BreakWall"))
        {
            Destroy(other.gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }
    }
}
