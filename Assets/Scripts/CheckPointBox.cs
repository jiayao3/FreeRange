using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBox : MonoBehaviour
{
    private int activated = 0;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Main Player" && activated == 0)
        {

            activated = 1;
        }
        
    }

}
