using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    public GameObject projectile;
    private float countDown;
    public float timeBetween;
    public float force;
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        countDown = timeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            GameObject bullet = Instantiate(projectile, transform.position + new Vector3(direction * 2, 0 , 0), transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(direction, 0, 0) * force, ForceMode.VelocityChange);
            countDown = timeBetween;
        }
        
    }
}
