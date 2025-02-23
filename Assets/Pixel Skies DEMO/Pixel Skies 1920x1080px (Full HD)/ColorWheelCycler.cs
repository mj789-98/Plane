using UnityEngine;
using System.Collections;

public class ColorWheelCycler : MonoBehaviour
{
    private Camera mainCamera;
    public float hueSpeed = 0.02f;    // Reduced from 0.1f to 0.02f
    private float currentHue = 0f;
    private float initialValue;
    private float initialSaturation;

    void Start()
    {
        mainCamera = Camera.main;
        Color.RGBToHSV(mainCamera.backgroundColor, out _, out initialSaturation, out initialValue);
        StartCoroutine(CycleColorWheel());
    }

    IEnumerator CycleColorWheel()
    {
        while (true)
        {
            Color newColor = Color.HSVToRGB(currentHue, 1f, initialValue);
            mainCamera.backgroundColor = newColor;
            
            currentHue += hueSpeed * Time.deltaTime;
            if (currentHue >= 1f) currentHue = 0f;
            
            yield return null;
        }
    }
}