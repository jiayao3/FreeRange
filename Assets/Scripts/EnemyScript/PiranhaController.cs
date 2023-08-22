using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaController : MonoBehaviour
{
    public float speed;
    public Transform start;
    public Transform end;
    private int direction = -1;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= start.position.x)
        {
            direction = 1;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -direction));
        } else if(transform.position.x >= end.position.x)
        {
            direction = -1;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -direction));
        }

        rb.velocity = new Vector3(direction * speed, 0, 0);
    }
}
