using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;

    private void Awake(){
        int unlockedLevel = PlayerPrefs.GetInt("HighScore_Level_", 1);
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
        for(int i = 0; i < unlockedLevel; i++){
            buttons[i].interactable = true;
        }

         for (int i = 0; i < 3; i++)
        {
            int highScore = PlayerPrefs.GetInt("HighScore_Level_" + (i + 1), 0);

            if (i > 0) // For levels after the first one
            {
                int requiredScore = i == 1 ? 10 : 20; // 10 for level 2, 20 for level 3

                if (PlayerPrefs.GetInt("HighScore_Level_" + i, 0) >= requiredScore)
                {
                    buttons[i].interactable = true;
                }
                else
                {
                    break; // Exit the loop if the condition isn't met for subsequent levels
                }
            }
            else // For the first level
            {
                buttons[i].interactable = true;
            }
        }
    }
    
    public void OpenLevel(int levelId){
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
        
    }

}
