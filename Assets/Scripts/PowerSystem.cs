using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerSystem : MonoBehaviour 
{
    public Image powerBarImage;
    public TextMeshProUGUI percentageText;
    public Button releaseButton;
    public float maxPower = 100f;
    public float powerPerStar = 20f;
    
    [Header("Visual Effects")]
    public Color emptyColor = Color.gray;
    public Color fullColor = Color.red;
    public Image glowEffect;  // Add a separate Image component for the glow
    public float glowIntensity = 1.5f;  // Control the glow brightness
    public float glowPulseSpeed = 2f;  // How fast the glow pulses
    
    private float currentPower = 0f;
    private bool isPowerReady = false;
    private float pulseTimer = 0f;

    void Start()
    {
        if (powerBarImage != null)
        {
            powerBarImage.fillAmount = 0f;
            powerBarImage.color = emptyColor;
        }

        // Initialize glow effect
        if (glowEffect != null)
        {
            glowEffect.gameObject.SetActive(false);
        }

        releaseButton.interactable = false;
        releaseButton.onClick.AddListener(ReleasePower);

        UpdatePercentageText();
    }

    void Update()
    {
        // Animate glow when power is full
        if (isPowerReady && glowEffect != null)
        {
            pulseTimer += Time.deltaTime * glowPulseSpeed;
            float pulseValue = (Mathf.Sin(pulseTimer) + 1f) / 2f;  // Oscillate between 0 and 1
            Color glowColor = fullColor * glowIntensity;
            glowColor.a = pulseValue;  // Pulse the alpha
            glowEffect.color = glowColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue_Meteor"))
        {
            currentPower += powerPerStar;
            
            powerBarImage.fillAmount = currentPower / maxPower;
            powerBarImage.color = Color.Lerp(emptyColor, fullColor, currentPower / maxPower);
            
            UpdatePercentageText();
            
         other.gameObject.SetActive(false);

            if (currentPower >= maxPower)
            {
                isPowerReady = true;
                releaseButton.interactable = true;
                
                // Activate glow effect when full
                if (glowEffect != null)
                {
                    glowEffect.gameObject.SetActive(true);
                }
            }
        }
    }

    void UpdatePercentageText()
    {
        if (percentageText != null)
        {
            int percentage = Mathf.RoundToInt((currentPower / maxPower) * 100);
            percentageText.text = percentage.ToString() + "%";
        }
    }

    public void ReleasePower()
    {
        if (isPowerReady)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy_Plane");
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }

            // Reset everything
            currentPower = 0f;
            isPowerReady = false;
            powerBarImage.fillAmount = 0f;
            powerBarImage.color = emptyColor;
            releaseButton.interactable = false;
            
            // Disable glow effect
            if (glowEffect != null)
            {
                glowEffect.gameObject.SetActive(false);
            }
            
            UpdatePercentageText();
        }
    }
}