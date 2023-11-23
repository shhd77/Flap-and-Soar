using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public GameObject playPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        playPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        playPanel.SetActive(true);
    }

    public void returnButton()
    {
        playPanel.SetActive(false);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsPage");
        Time.timeScale = 1;
    }


    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
