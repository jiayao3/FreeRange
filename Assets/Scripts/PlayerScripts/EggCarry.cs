using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCarry : MonoBehaviour
{
    [SerializeField] GameObject egg1;
    [SerializeField] GameObject egg2;
    [SerializeField] GameObject egg3;
    [SerializeField] GameObject fireChicken;
    private bool deactive1 = false;
    private bool deactive2 = false;
    private bool deactive3 = false;

    // Update is called once per frame
    void Update()
    {
         CarryEgg(PlayerChange.getEggActivated());
    }

    private void CarryEgg(int index)
    {
        if (index >= 1 && !deactive1)
        {
            egg1.GetComponent<MeshRenderer>().enabled = true;
        }
        if (index >= 2 && !deactive2)
        {
            egg2.GetComponent<MeshRenderer>().enabled = true;
        }
        if (index >= 3 && !deactive3)
        {
            egg3.GetComponent<MeshRenderer>().enabled = true;
        }
        if (index == 4)
        {
            fireChicken.SetActive(true);
        }
    }


    public void DeactiveEgg(int index)
    {
        if (index == 1)
        {
            egg1.GetComponent<MeshRenderer>().enabled = false;
            deactive1 = true;
        }
        if (index == 2)
        {
            egg2.GetComponent<MeshRenderer>().enabled = false;
            deactive2 = true;
        }
        if (index == 3)
        {
            egg3.GetComponent<MeshRenderer>().enabled = false;
            deactive3 = true;
        }
        
    }

    public void ActiveEgg(int index)
    {
        if (index == 1)
        {
            deactive1 = false;
        }
        else if (index == 2)
        {
            deactive2 = false;
        }
        else if (index == 3)
        {
            deactive3 = false;
        }
    }
}
