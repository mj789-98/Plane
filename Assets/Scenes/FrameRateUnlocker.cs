using UnityEngine;

public class FrameRateUnlocker : MonoBehaviour
{
    void Awake()
    {
        // Disable VSync
        QualitySettings.vSyncCount = 0;
        
        // If in editor or PC build, set unlimited frame rate
        if (Application.platform == RuntimePlatform.WindowsEditor || 
            Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Application.targetFrameRate = -1;
        }
        // On mobile, cap at 120
        else
        {
            Application.targetFrameRate = 120;
        }

        // Force settings again after delay
        Invoke("ForceFrameRate", 1f);
    }

    void ForceFrameRate()
    {
        QualitySettings.vSyncCount = 0;
        
        if (Application.platform == RuntimePlatform.WindowsEditor || 
            Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Application.targetFrameRate = -1;
        }
        else
        {
            Application.targetFrameRate = 120;
        }
    }
}