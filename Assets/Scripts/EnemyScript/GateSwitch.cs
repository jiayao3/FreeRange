using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    [SerializeField] GameObject GateLeft;
    [SerializeField] GameObject GateRight;
    public float speed;
    private int opened = 0; // 0: close, 1: opening, 2: opened
    [SerializeField] GameObject greenButton;
    [SerializeField] GameObject redButton;
    [SerializeField] AudioSource openSound;
    // Start is called before the first frame update
    void Start()
    {
        greenButton.SetActive(false);
    }

    private void Update()
    {
        if (opened == 1)
        {
            GateLeft.transform.Rotate(new Vector3(0, 1 * Time.deltaTime * speed, 0) , -90f);
            GateRight.transform.Rotate(new Vector3(0, 1 * Time.deltaTime * speed, 0) , 90f);
            opened = 2;
            greenButton.SetActive(true);
            redButton.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Main Player") && opened != 2)
        {
            openSound.Play();
            opened = 1;
        }
    }

 
}
