using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Outofbounds : MonoBehaviour
{
    private float rightLimit = 15;
    private float bottomLimit = -15;
    private float topLimit = 15;
    private float leftLimit = -45;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x > rightLimit)
        {
            Destroy(gameObject);
        }
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > topLimit)
        {
            Destroy (gameObject);
        }
        else if(transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }

    }
}
