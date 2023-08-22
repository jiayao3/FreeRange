using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool Paused = false;
    public GameObject pauseMenu;
    [SerializeField] AudioSource pauseSound;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] GameObject controlMenu;


    private void Start()
    {
        controlMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pauseSound.Play();
            if (Paused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        buttonSound.Play();
        pauseMenu.SetActive(false);
        controlMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void MainMenu()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ControlMenu()
    {
        buttonSound.Play();
        controlMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void BackToPauseMenu()
    {
        buttonSound.Play();
        controlMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
