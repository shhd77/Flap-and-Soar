using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject playPanel;
    public GameObject leadPanel;
    public GameObject settingPanel;
    public GameObject instructionsPanel;
    public TextMeshProUGUI[] levelTexts;
    public TextMeshProUGUI[] highScoreTexts;
    public TextMeshProUGUI soundText;
    private bool isMuted = false;


    // Start is called before the first frame update
    void Start()
    {
        playPanel.SetActive(false);
        leadPanel.SetActive(false);
        settingPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        soundText.text = "SOUND: ON";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
        if(isMuted){
            soundText.text = "SOUND: OFF";
        } else{
            soundText.text = "SOUND: ON";
        }
    }

    public void playButton()
    {
        playPanel.SetActive(true);
    }

    public void instructionsButton()
    {
        instructionsPanel.SetActive(true);
    }

    public void leadButton()
    {
        leadPanel.SetActive(true);
        DisplayHighScores();
    }

    public void returnLeadButton()
    {
        leadPanel.SetActive(false);
    }

    public void returnButton()
    {
        playPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }

    public void returnSettingButton()
    {
        settingPanel.SetActive(false);
    }

    public void closeButton1()
    {
        instructionsPanel.SetActive(false);
    }

    public void settingButton()
    {
        settingPanel.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void DisplayHighScores()
    {
        int totalLevels = 3;
        for (int level = 1; level <= totalLevels; level++)
        {
            int highScore = PlayerPrefs.GetInt("HighScore_Level_" + level, 0);
            levelTexts[level - 1].text = "Level :" + level;
            highScoreTexts[level - 1].text = "High Score: " + highScore;
        }
    }

    public void ResetHighScoresButton()
    {
        int totalLevels = 3; // Change this value to match your total number of levels

        for (int i = 1; i <= totalLevels; i++)
        {
            PlayerPrefs.SetInt("HighScore_Level_" + i, 0);
        }

        PlayerPrefs.Save();
    }
}
