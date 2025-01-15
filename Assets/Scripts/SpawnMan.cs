using UnityEngine;
using System.Collections.Generic;

public class SpawnMan : MonoBehaviour 
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
        public Queue<GameObject> pooledObjects;
    }

    [Header("Spawn Settings")]
    public Pool[] pools;
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

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                // Store the initial active states of all children
                SetInitialChildStates(obj);
                obj.SetActive(false);
                pool.pooledObjects.Enqueue(obj);
            }
        }
    }

    // Store the initial active states of children
    private void SetInitialChildStates(GameObject obj)
    {
        // Store the initial state in a component
        ObjectStateManager stateManager = obj.AddComponent<ObjectStateManager>();
        stateManager.SaveChildStates();
    }

    private GameObject GetPooledObject(int poolIndex)
    {
        if (poolIndex < 0 || poolIndex >= pools.Length)
        {
            Debug.LogError("Invalid pool index!");
            return null;
        }

        Pool pool = pools[poolIndex];

        if (pool.pooledObjects.Count > 0)
        {
            GameObject obj = pool.pooledObjects.Dequeue();
            obj.SetActive(true);
            // Restore child objects' states
            ObjectStateManager stateManager = obj.GetComponent<ObjectStateManager>();
            if (stateManager != null)
            {
                stateManager.RestoreChildStates();
            }
            return obj;
        }

        GameObject newObj = Instantiate(pool.prefab);
        SetInitialChildStates(newObj);
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
            StartCoroutine(ReturnToPoolAfterDelay(ball, pools[poolIndex], 5f));
        }
    }

    private System.Collections.IEnumerator ReturnToPoolAfterDelay(GameObject obj, Pool pool, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool(obj, pool);
    }
}

// New component to manage object states
public class ObjectStateManager : MonoBehaviour
{
    private Dictionary<Transform, bool> childStates = new Dictionary<Transform, bool>();

    public void SaveChildStates()
    {
        childStates.Clear();
        SaveChildStatesRecursive(transform);
    }

    private void SaveChildStatesRecursive(Transform parent)
    {
        foreach (Transform child in parent)
        {
            childStates[child] = child.gameObject.activeSelf;
            SaveChildStatesRecursive(child);
        }
    }

    public void RestoreChildStates()
    {
        foreach (var kvp in childStates)
        {
            if (kvp.Key != null) // Make sure the child still exists
            {
                kvp.Key.gameObject.SetActive(kvp.Value);
            }
        }
    }
}