using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Right : MonoBehaviour
{
    public float initialSpeed = 10f;  // Initial movement speed
    public float speedIncreaseRate = 1f;  // How much speed increases per second
    public float maxSpeed = 100f;  // Maximum speed limit
    
    private float currentSpeed;
    private float elapsedTime = 0f;
    private PlayerMovement playerControllerScript;
    private float leftBound = -10;

    void Start()
    {
        currentSpeed = initialSpeed;
        Debug.Log($"[{gameObject.name}] Starting with initial speed: {currentSpeed}");
    }

    void Update()
    {
        // Increase speed over time
        elapsedTime += Time.deltaTime;
        currentSpeed = Mathf.Min(initialSpeed + (speedIncreaseRate * elapsedTime), maxSpeed);
        
        // Log speed every 5 seconds
        if (Mathf.Floor(elapsedTime) % 5 == 0 && Time.frameCount % 30 == 0)  // Only log every 30 frames when on a 5 second mark
        {
            Debug.Log($"[{gameObject.name}] Current speed: {currentSpeed:F2} at time: {elapsedTime:F1}s");
        }

        // Move the object
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime, Space.World);

        /*  // If game is not over, move to the left
          if (!playerControllerScript.gameOver)
          {*/
        /*}*/

        /*   // If object goes off screen that is NOT the background, destroy it
           if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
           {
               Destroy(gameObject);
           }*/
    }

    // Optional: Add this method to get the current speed for other scripts
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}