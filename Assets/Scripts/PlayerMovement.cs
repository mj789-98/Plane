using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool gameOver;


    //variables    
    public float moveSpeed = 300;
    public GameObject character;
    private Rigidbody characterBody;
    private float ScreenWidth;
    private Animator animator;
    private new ParticleSystem particleSystem;
    public float moveSensitivity = 100.0f;


    // Use this for initialization    
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
        // Get the touch information

    }








    // Update is called once per frame    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 15));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
               
            }
        }





        int i = 0;
        //loop over every touch found    
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {

                //move right

                animator.SetBool("isIdle", true);
                particleSystem.Stop();







            }

            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left    


                animator.SetBool("isIdle", false);
            
                particleSystem.Play();







            }
            ++i;




        }
    }




}









