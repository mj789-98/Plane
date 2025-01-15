using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    [Header("UI Settings")]
    public TextMeshProUGUI fpsText;
    public float updateInterval = 0.5f;  // How often to update the FPS display

    [Header("Display Settings")]
    public bool showAverage = true;      // Show average FPS
    public bool showMin = true;          // Show minimum FPS
    public bool showMax = true;          // Show maximum FPS
    
    private float accum = 0f;            // FPS accumulated over the interval
    private int frames = 0;              // Frames drawn over the interval
    private float timeleft;              // Left time for current interval
    private float currentFPS = 0f;       // Current FPS
    private float minFPS = float.MaxValue;
    private float maxFPS = 0f;

    void Start()
    {
        if (fpsText == null)
        {
            Debug.LogError("Please assign a TextMeshProUGUI component!");
            enabled = false;
            return;
        }

        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;

        // Calculate FPS and update display when the interval has elapsed
        if (timeleft <= 0.0f)
        {
            currentFPS = accum / frames;
            
            if (currentFPS < minFPS) minFPS = currentFPS;
            if (currentFPS > maxFPS) maxFPS = currentFPS;

            string display = "";
            
            if (showAverage)
                display += $"FPS: {Mathf.Round(currentFPS)}\n";
            
            if (showMin)
                display += $"Min: {Mathf.Round(minFPS)}\n";
            
            if (showMax)
                display += $"Max: {Mathf.Round(maxFPS)}";

            fpsText.text = display;

            // Reset variables for next interval
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }

    // Optional: Method to reset min/max values
    public void ResetMinMax()
    {
        minFPS = float.MaxValue;
        maxFPS = 0f;
    }
}