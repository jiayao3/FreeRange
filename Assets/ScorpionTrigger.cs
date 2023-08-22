using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionTrigger : MonoBehaviour
{
    public GameObject scorpion;
    public GameObject moveTo;
    GameObject enemy;
    public GameObject player;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && enemy.transform.position.y <= moveTo.transform.position.y)
        {
            Debug.Log("Hi");
            enemy.transform.position = enemy.transform.position + new Vector3(0, 2 * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Main Player")
        {
            enemy = Instantiate(scorpion, transform.position + new Vector3(0,1,0), transform.rotation);
            enemy.GetComponent<ScorpionController>().SetPlayer(player);
            Instantiate(effect, transform.position + new Vector3(0, 1, 0), transform.rotation);
            //enemy.GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
            Destroy(gameObject);
        }
    }


}
