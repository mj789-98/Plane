using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PowerSystem : MonoBehaviour 
{
    [Header("UI Elements")]
    public Image powerBarImage;
    public TextMeshProUGUI percentageText;
    public Button releaseButton;
    
    [Header("Power Settings")]
    public float maxPower = 100f;
    public float powerPerStar = 20f;
    public float glowPulseSpeed = 2f;
    
    [Header("Visual Effects")]
    public Color emptyColor = Color.gray;
    public Color fullColor = Color.red;
    
    [Header("Explosion Settings")]
    public GameObject explosionPrefab;
    
    private float currentPower = 0f;
    private bool isPowerReady = false;
    private float pulseTimer = 0f;
    
    void Start()
    {
        InitializeUI();
    }
    
    void Update()
    {
        if (isPowerReady)
        {
            pulseTimer += Time.deltaTime * glowPulseSpeed;
            float pulseValue = (Mathf.Sin(pulseTimer) + 1f) / 2f;
            Color pulseColor = Color.Lerp(fullColor, fullColor * 1.5f, pulseValue);
            pulseColor.a = 0.9f;
            powerBarImage.color = pulseColor;
        }
    }

    void InitializeUI()
    {
        powerBarImage.fillAmount = 0f;
        powerBarImage.color = emptyColor;
        releaseButton.interactable = false;
        releaseButton.onClick.AddListener(ReleasePower);
        UpdatePercentageText();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue_Meteor"))
        {
            CollectPower(other.gameObject);
        }
    }

    void CollectPower(GameObject meteor)
    {
        currentPower = Mathf.Min(currentPower + powerPerStar, maxPower);
        powerBarImage.fillAmount = currentPower / maxPower;
        
        if (!isPowerReady)
        {
            powerBarImage.color = Color.Lerp(emptyColor, fullColor, currentPower / maxPower);
        }
        
        UpdatePercentageText();
        meteor.SetActive(false);
        
        if (currentPower >= maxPower)
        {
            ActivatePowerReady();
        }
    }
    
    void ActivatePowerReady()
    {
        isPowerReady = true;
        releaseButton.interactable = true;
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
                CreateExplosion(enemy.transform.position);
                enemy.SetActive(false);
            }
            ResetPowerSystem();
        }
    }
    
    void CreateExplosion(Vector3 position)
    {
        GameObject explosionObj = Instantiate(explosionPrefab, position, Quaternion.identity);
        // Tag the main explosion object if it's not already tagged
        if (!explosionObj.CompareTag("ExplosionEffect"))
        {
            explosionObj.tag = "ExplosionEffect";
        }
        
        Exploder exploder = explosionObj.GetComponent<Exploder>();
        
        if (exploder != null)
        {
            exploder.explosionTime = Time.time;
            
            float maxDuration = exploder.explodeDuration;
            
            // Get the volumetric component to calculate max duration
            PseudoVolumetricComponent volumetricComp = explosionObj.GetComponent<PseudoVolumetricComponent>();
            if (volumetricComp != null)
            {
                maxDuration = Mathf.Max(maxDuration, volumetricComp.duration * (1 + volumetricComp.randomness));
            }
            
            // Add a small buffer to ensure all effects are complete
            maxDuration += 0.5f;
            
            StartCoroutine(CleanupExplosionEffects(maxDuration));
        }
    }
    
    IEnumerator CleanupExplosionEffects(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        // Find and destroy ALL objects tagged as ExplosionEffect
        GameObject[] effectObjects = GameObject.FindGameObjectsWithTag("ExplosionEffect");
        foreach (GameObject obj in effectObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }
    
    void ResetPowerSystem()
    {
        currentPower = 0f;
        isPowerReady = false;
        powerBarImage.fillAmount = 0f;
        powerBarImage.color = emptyColor;
        releaseButton.interactable = false;
        UpdatePercentageText();
    }
}