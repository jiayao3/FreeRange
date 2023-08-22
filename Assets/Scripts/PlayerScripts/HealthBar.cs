using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject Player;
    public GameObject gameOverMenu;

    private void Update()
    {
        health = Player.GetComponent<Health>().GetHealth();
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        if (health == 0)
        {
            gameOverMenu.SetActive(true);
        }
    }



}
