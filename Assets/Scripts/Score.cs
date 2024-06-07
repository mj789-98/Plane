using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float timeElapsed;
    public int score;
    public Text scoreText;

      public TextMeshProUGUI distanceText;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        score = CalculateScore();
        distanceText.text = "Score: " + score;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(timeElapsed * 1);
    }
}
