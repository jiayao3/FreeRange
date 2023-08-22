using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public bool active = false;

    // Update is called once per frame
    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }
}
