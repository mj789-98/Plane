using UnityEngine;

public class FrameRateSettings : MonoBehaviour
{
    void Start()
    {
        // Disable VSync
        QualitySettings.vSyncCount = 0;
        
        // Unlock frame rate (-1 means no limit)
        Application.targetFrameRate = -1;
    }
}