using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMan : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    


    private float spawnLimitXLeft = -37;
    private float spawnLimitXRight = -35;
    private float spawnPosY = 5;
    private float spawnPosZ = -4.5f;

    private float startDelay = 1;
    private float spawnInterval = 3.0f;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
       

    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, spawnPosZ);


        // instantiate ball at random spawn location
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
        Invoke("SpawnRandomBall", Random.Range(1, 5));
     
    }

}
