using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStageScript : MonoBehaviour
{
    private bool done = true;
    [SerializeField] GameObject dialog;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject snake;

    // Start is called before the first frame update
    void Start()
    {
        if (UI)
        {
            UI.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            PlayerChange.SetEggActivated(3);
            done = false;
        }
        if (PlayerChange.getEggActivated() == 4 && dialog)
        {
            dialog.SetActive(false);
        }
        if (dialog == null)
        {
            snake.SetActive(true);
        }
        else
        {
            snake.SetActive(false);
        }
    }
}
