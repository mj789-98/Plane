using UnityEngine;
using System.Collections;

public class BackgroundCycler : MonoBehaviour
{
    public GameObject[] backgrounds;
    public float switchDelay = 2f;
    private int currentIndex = 0;

    void Start()
    {
        StartCoroutine(CycleBackgrounds());
    }

    IEnumerator CycleBackgrounds()
    {
        while (true)
        {
            // Disable all backgrounds
            foreach (GameObject bg in backgrounds)
            {
                bg.SetActive(false);
            }

            // Enable current background
            backgrounds[currentIndex].SetActive(true);

            // Update index
            currentIndex = (currentIndex + 1) % backgrounds.Length;

            yield return new WaitForSeconds(switchDelay);
        }
    }
}