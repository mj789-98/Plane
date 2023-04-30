using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float timeElapsed;
    public int score;
    public Text scoreText;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        score = CalculateScore();
        scoreText.text = "Score: " + score;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(timeElapsed * 1);
    }
}
