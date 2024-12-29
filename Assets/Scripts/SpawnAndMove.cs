using UnityEngine;

public class SpawnAndMove : MonoBehaviour 
{
    public GameObject[] ballPrefabs;
    
    private float spawnLimitYMin = -7;    // Minimum Y position
    private float spawnLimitYMax = 8;     // Maximum Y position
    
    private float spawnPosX = -31;        // Fixed X position
    private float spawnPosZ = -5;         // Fixed Z position
    
    private float startDelay = 5f;
    private float spawnInterval = 2f;     // Fixed spawn interval

    // Add variables to control rotation
    public Vector3 spawnRotation = new Vector3(0, 90, 0); // Adjust these values as needed
    
    void Start()
    {
        if (ballPrefabs.Length == 0)
        {
            Debug.LogError("No ball prefabs assigned to the script!");
            return;
        }
        
        // Start spawning balls at a fixed interval
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }
    
    void SpawnRandomBall()
    {
        // Generate a random Y position within the specified range
        float randomY = Random.Range(spawnLimitYMin, spawnLimitYMax);
        Vector3 spawnPos = new Vector3(spawnPosX, randomY, spawnPosZ);
        
        // Create rotation using Euler angles
        Quaternion rotation = Quaternion.Euler(spawnRotation);
        
        // Instantiate a random ball prefab with the specified rotation
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, rotation);
    }
}