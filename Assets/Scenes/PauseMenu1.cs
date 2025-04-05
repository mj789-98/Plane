using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu1 : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public Button pauseButton;

    private void Start()
    {
        // Ensure panel is inactive on start
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        
        pauseButton.onClick.AddListener(TogglePauseGame);
    }

    void TogglePauseGame()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        pauseMenuUI.SetActive(false); // Ensure panel is inactive before reload
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // This ensures the panel is inactive if the scene is reloaded from elsewhere
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}