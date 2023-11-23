using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI highscoreText2;
    public GameObject gameOverPanel;
    public AudioSource pointSound;
    public int currentLevel = 1;

    [ContextMenu("Increase Score")]

    void Start(){
        gameOverPanel.SetActive(false);
        UpdateScoreText();
        DisplayLevelAndHighScore();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void AddScore(){
        playerScore += 1;
        pointSound.Play();
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null && scoreText2 != null)
        {
            scoreText.text = playerScore.ToString();
            scoreText.text = "SCORE: " + playerScore.ToString();
            scoreText2.text = playerScore.ToString();
            scoreText2.text = "SCORE: " + playerScore.ToString();
        }
    }
    

    public void GameOver()
    {
        int highScore = PlayerPrefs.GetInt("HighScore_Level_" + currentLevel, 0);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore_Level_" + currentLevel, playerScore);
            PlayerPrefs.Save();
            Debug.Log("New High Score: " + playerScore);
            DisplayLevelAndHighScore();
        }
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    void DisplayLevelAndHighScore()
    {
        if (currentLevelText != null)
        {
            currentLevelText.text = "LEVEL: " + currentLevel.ToString();
        }

        int highScore = PlayerPrefs.GetInt("HighScore_Level_" + currentLevel, 0);
        if (highscoreText != null && highscoreText2 != null)
        {
            highscoreText.text = "HIGH SCORE: " + highScore.ToString();
            highscoreText2.text = "HIGH SCORE: " + highScore.ToString();
        }
    }

}
