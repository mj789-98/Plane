using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("References")]
    public GameObject explosionPrefab;
    public GameObject mainMenuPanel;
    public GameObject player;
    public AudioClip explosionSound;

    [Header("Explosion Settings")]
    public float explosionDuration = 2f;
    [Range(0f, 1f)]
    public float explosionVolume = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy_Plane"))
        {
            HandleCollision(collision.gameObject);
        }
    }

    private void HandleCollision(GameObject enemyPlane)
    {
        // Create explosion at collision point BEFORE disabling objects
        Vector3 collisionPosition = player.transform.position;
        CreateExplosionWithSound(collisionPosition);

        // Disable objects after creating explosion
        player.SetActive(false);
        enemyPlane.SetActive(false);

        // Wait for explosion then show menu
        Invoke("ShowMainMenu", explosionDuration);
    }

    private void CreateExplosionWithSound(Vector3 position)
    {
        // Create explosion object
        GameObject explosionObj = Instantiate(explosionPrefab, position, Quaternion.identity);
        
        // Add audio source to explosion object
        AudioSource audioSource = explosionObj.AddComponent<AudioSource>();
        audioSource.clip = explosionSound;
        audioSource.volume = explosionVolume;
        audioSource.playOnAwake = false;
        audioSource.Play();

        Exploder exploder = explosionObj.GetComponent<Exploder>();
        if (exploder != null)
        {
            exploder.explosionTime = Time.time;
            
            ParticleComponent particleComp = explosionObj.GetComponent<ParticleComponent>();
            PseudoVolumetricComponent volumetricComp = explosionObj.GetComponent<PseudoVolumetricComponent>();
            
            float maxDuration = exploder.explodeDuration;
            if (volumetricComp != null)
            {
                maxDuration = Mathf.Max(maxDuration, volumetricComp.duration * (1 + volumetricComp.randomness));
            }
            
            // Make sure maxDuration is long enough for sound to play
            maxDuration = Mathf.Max(maxDuration, explosionSound != null ? explosionSound.length : 0f);
            
            StartCoroutine(CleanupExplosionEffects(explosionObj, maxDuration));
        }
    }

    private System.Collections.IEnumerator CleanupExplosionEffects(GameObject explosionObj, float delay)
    {
        yield return new WaitForSeconds(delay);
        
        // Find and destroy all explosion effects
        GameObject[] effectObjects = GameObject.FindGameObjectsWithTag("ExplosionEffect");
        foreach (GameObject obj in effectObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        
        Destroy(explosionObj);
    }

    private void ShowMainMenu()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Main Menu Panel reference is missing!");
        }
    }
}