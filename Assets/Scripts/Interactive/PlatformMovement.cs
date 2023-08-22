using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed;
    public Transform start;
    public Transform end;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, end.position.x - start.position.x) + start.position.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Main Player" || other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Main Player" || other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
