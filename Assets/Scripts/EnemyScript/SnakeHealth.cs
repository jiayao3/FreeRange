using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHealth : MonoBehaviour
{
    public Slider slider;
    
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    
    public void SetMax(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
