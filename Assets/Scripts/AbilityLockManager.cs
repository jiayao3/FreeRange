using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLockManager : MonoBehaviour
{
    int locked;
    public Image[] locks;
    public Sprite lockSprite;
    public GameObject UI;

    private void Start()
    {
        if (UI)
        {
            UI.SetActive(true);
        }
        
    }

    private void Update()
    {
        locked = PlayerChange.getEggActivated();
        for (int i = 0; i < locked; i++)
        {
            if (locked < 4)
            {
                locks[i].enabled = false;
            }
                
        }
        
    }
}
