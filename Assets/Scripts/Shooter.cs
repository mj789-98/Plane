using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
   
   

    void Update()
    {
     /*   if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Create an instance of the projectile prefab
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Get the Rigidbody component of the projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            // Apply a force to the projectile in the forward direction
            rb.AddForce(-transform.right * 1000f);
        }*/


    }

   public void shoot()
    {
        // Create an instance of the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
           
        // Get the Rigidbody component of the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Apply a force to the projectile in the forward direction
        rb.AddForce(-transform.right * 1000f);
       
    }
}

