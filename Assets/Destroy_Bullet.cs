using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    private float bottomLimit = -15;
    private float topLimit = 9;
    private float leftLimit = -38;

    // Update is called once per frame
    void Update()
    {



         if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > topLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }

    }
}
