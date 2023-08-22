using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 1;
    void Awake()
    {
        if (gameObject)
        {
            Destroy(gameObject, lifeTime);
        }
        
    }

}
