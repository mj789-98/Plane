using UnityEngine;
using System.Collections.Generic;

public class SpawnAndMove : MonoBehaviour 
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
        public Queue<GameObject> pooledObjects;
    }

    [Header("Spawn Settings")]
    public Pool[] pools;  // Array of different ball pools
    public float spawnLimitYMin = -7f;
    public float spawnLimitYMax = 8f;
    public float spawnPosX = -31f;
    public float spawnPosZ = -5f;
    public float startDelay = 5f;
    public float spawnInterval = 2f;
    public Vector3 spawnRotation = new Vector3(0, 90, 0);

    private void Start()
    {
        InitializePools();
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    private void InitializePools()
    {
        foreach (Pool pool in pools)
        {
            pool.pooledObjects = new Queue<GameObject>();

            // Create the initial pool of objects
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                pool.pooledObjects.Enqueue(obj);
            }
        }
    }

    private GameObject GetPooledObject(int poolIndex)
    {
        if (poolIndex < 0 || poolIndex >= pools.Length)
        {
            Debug.LogError("Invalid pool index!");
            return null;
        }

        Pool pool = pools[poolIndex];

        // If there's an inactive object in the pool, use it
        if (pool.pooledObjects.Count > 0)
        {
            GameObject obj = pool.pooledObjects.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        // If we need more objects, create a new one
        GameObject newObj = Instantiate(pool.prefab);
        return newObj;
    }

    private void ReturnToPool(GameObject obj, Pool pool)
    {
        obj.SetActive(false);
        pool.pooledObjects.Enqueue(obj);
    }

    private void SpawnRandomBall()
    {
        float randomY = Random.Range(spawnLimitYMin, spawnLimitYMax);
        Vector3 spawnPos = new Vector3(spawnPosX, randomY, spawnPosZ);
        Quaternion rotation = Quaternion.Euler(spawnRotation);

        int poolIndex = Random.Range(0, pools.Length);
        GameObject ball = GetPooledObject(poolIndex);

        if (ball != null)
        {
            ball.transform.position = spawnPos;
            ball.transform.rotation = rotation;

            // Automatically return the ball to the pool after some time
            // You should adjust this based on your game's needs
            StartCoroutine(ReturnToPoolAfterDelay(ball, pools[poolIndex], 5f));
        }
    }

    private System.Collections.IEnumerator ReturnToPoolAfterDelay(GameObject obj, Pool pool, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool(obj, pool);
    }
}