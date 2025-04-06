using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Game : MonoBehaviour
{
    // load level and save current score if going to home screen
    public void LoadLevel(string levelName)
    {
        // If loading home screen, save current score
        if (levelName == "Menu")
        {
            var scoreObj = FindObjectOfType<Score>();
            if (scoreObj != null)
            {
                GameManager.TrySetNewHighScore(scoreObj.score); // Save the score
                // HighScoreDisplay in the HomeScene will update itself via OnEnable
            }
        }
        SceneManager.LoadScene(levelName);
    }
}
