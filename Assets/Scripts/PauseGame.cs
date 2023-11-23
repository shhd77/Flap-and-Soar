using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;
    public AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            buttonSound.Play();
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    public void Unpause()
    {
        buttonSound.Play();
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        buttonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

}
