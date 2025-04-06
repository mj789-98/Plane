using UnityEngine;

public static class GameManager
{
    private static int highScore;
    private const string HighScoreKey = "HighScore"; // Key for PlayerPrefs

    // Static constructor to load the high score when the class is first accessed
    static GameManager()
    {
        // Load the high score from PlayerPrefs, defaulting to 0 if not found
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        Debug.Log("GameManager initialized. Loaded High Score: " + highScore);
    }

    // Method to get the current high score
    public static int GetHighScore()
    {
        return highScore;
    }

    // Method to update the high score if the new score is higher
    public static bool TrySetNewHighScore(int newScore)
    {
        Debug.Log($"Checking high score. Current: {highScore}, New: {newScore}");
        if (newScore > highScore)
        {
            highScore = newScore;
            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            bool saveSuccess = PlayerPrefs.HasKey(HighScoreKey);
            PlayerPrefs.Save(); // Ensure data is written to disk
            Debug.Log($"New High Score set: {highScore}. Save successful: {saveSuccess}");
            return true;
        }
        Debug.Log("Score not higher than current high score");
        return false;
    }

    // Optional: Method to reset the high score (for testing or game options)
    public static void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();
        Debug.Log("High Score reset to 0.");
    }
}
