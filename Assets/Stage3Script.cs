using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Script : MonoBehaviour
{
    private bool done = true;
    [SerializeField] GameObject dialog;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
        UI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            PlayerChange.SetEggActivated(2);
            done = false;
        }
        if (PlayerChange.getEggActivated() == 3 && dialog)
        {
            dialog.SetActive(true);
        }
    }
}
