using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Right : MonoBehaviour
{
    public float speed;
    private PlayerMovement playerControllerScript;
    private float leftBound = -10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*  // If game is not over, move to the left
          if (!playerControllerScript.gameOver)
          {*/
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        //}

        /*   // If object goes off screen that is NOT the background, destroy it
           if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
           {
               Destroy(gameObject);
           }*/

    }
}
