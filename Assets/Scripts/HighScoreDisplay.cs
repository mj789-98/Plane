using UnityEngine;
using TMPro; // Make sure to import TextMeshPro

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; // Assign this in the Unity Inspector

    void OnEnable()
    {
        RefreshHighScoreDisplay();
    }

    public void RefreshHighScoreDisplay()
    {
        if (highScoreText == null)
        {
            Debug.LogError("HighScoreDisplay: highScoreText is not assigned in the Inspector!");
            return;
        }

        int highScore = GameManager.GetHighScore();
        highScoreText.text = "High Score: " + highScore;
        Debug.Log($"Displaying high score: {highScore}");
    }

    // You might add an Update method if the high score could change while the home scene is active,
    // but typically it's loaded once when the scene starts.
    // void Update() { } 
}
