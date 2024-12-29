using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip destructionSound;  // Assign your destruction sound in the inspector
    private AudioSource audioSource;
    private bool isDestroyed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isDestroyed && collision.gameObject.CompareTag("Enemy_Plane"))
        {
            isDestroyed = true;
            PlayDestructionSound();
            Destroy(collision.gameObject);  // Optional: destroys the enemy plane as well
            Invoke("DestroyPlane", destructionSound.length);
        }
    }

    void PlayDestructionSound()
    {
        audioSource.PlayOneShot(destructionSound);
    }

    void DestroyPlane()
    {
        Destroy(gameObject);
    }
}
