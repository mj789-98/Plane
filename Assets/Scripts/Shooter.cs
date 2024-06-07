using UnityEngine;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour
{
    public float delayInSeconds = 4f;
    public MonoBehaviour PlayerMovement;
    private bool shootButtonPressed = false;
    public GameObject projectilePrefab;

   
    void Start()
     {
        
    }
    void Update()
    {
       
    }

    public void OnShootButtonDown()
    {


       Debug.Log("Yeah buddy");

      
       
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        

        shootButtonPressed = true;
        shoot();

    }

       
    

    public void OnShootButtonUp()
    {
        Debug.Log("shoot button up");
        // Disable player movement
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        
        shootButtonPressed = false;
       
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

    public bool IsShootButtonPressed()
    {
        return shootButtonPressed;
    }
}

