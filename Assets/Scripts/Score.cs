using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float timeElapsed;
    public int score { get; private set; }
    public Text scoreText;
    public TextMeshProUGUI distanceText;
    public GameObject player; // Reference to player GameObject
    private bool isAlive = true;

    void Update()
    {
        // Stop if player is inactive, destroyed, or dead
        if ((player != null && !player.activeInHierarchy) || !isAlive)
        {
            if (distanceText != null)
                distanceText.text = "Final Score: " + score;
            return;
        }

        timeElapsed += Time.deltaTime;
        score = CalculateScore();
        distanceText.text = "Score: " + score;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(timeElapsed * 1);
    }

    // Call this when player dies to stop scoring
    public void PlayerDied()
    {
        if (isAlive)
        {
            isAlive = false;
            GameManager.TrySetNewHighScore(score);
            Debug.Log($"Score stopped and saved: {score}");
        }
    }
}
