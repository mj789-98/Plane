using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
	public MonoBehaviour Shooter;
	private bool isShooting = false;


  
	public bool gameOver;
	private Shooter shootButton;

   
 


   






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
        

		shootButton = GameObject.FindObjectOfType<Shooter>();
      
      
	}






    


	// Update is called once per frame    
	void Update()
	{
		MovePlayer();
       



	}
  

   
   
	private void MovePlayer()
 { 
   
    
 
	 if (ControlFreak2.CF2Input.touchCount > 0)
	 {
		 ControlFreak2.InputRig.Touch touch = ControlFreak2.CF2Input.GetTouch(0); // get first touch since touch count is greater than zero

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
	 while (i < ControlFreak2.CF2Input.touchCount)
	 {
		 if (ControlFreak2.CF2Input.GetTouch(i).position.x > ScreenWidth / 2)
		 {

			 //move right

			 animator.SetBool("isIdle", true);
			 particleSystem.Stop();







		 }

		 if (ControlFreak2.CF2Input.GetTouch(i).position.x < ScreenWidth / 2)
		 {
			 //move left    


			 animator.SetBool("isIdle", false);

			 particleSystem.Play();







		 }
		 ++i;




	 }
 }
 
}