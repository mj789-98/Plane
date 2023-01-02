using System.Collections;
using UnityEngine;

public class RandomInstantiator : MonoBehaviour
{
   
    public GameObject projectilePrefab;
   
    public Rigidbody rb;

    void Start()
    {
        StartCoroutine(SpawnObject());
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        rb = projectile.GetComponent<Rigidbody>();
       
       
    }


    IEnumerator SpawnObject()
    {
        while (true)
        {
            float randomX = Random.Range(-5.0f, 5.0f);
            float randomY = Random.Range(-5.0f, 5.0f);
            Vector3 randomPos = new Vector3(randomX, randomY, 0);
            GameObject instance = Instantiate(projectilePrefab, randomPos, Quaternion.identity);
            rb.AddForce(-transform.right * 500f);




            yield return new WaitForSeconds(1.0f);
        }
    }
}

