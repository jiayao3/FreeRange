using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public AudioSource sound;
    public void Stage1()
    {
        sound.Play();
        SceneManager.LoadScene(2);
    }

    public void Stage2()
    {
        sound.Play();
        SceneManager.LoadScene(3);
    }

    public void FinalStage()
    {
        sound.Play();
        SceneManager.LoadScene(4);
    }

    public void Boss()
    {
        sound.Play();
        SceneManager.LoadScene(5);
    }

    public void Back()
    {
        sound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
