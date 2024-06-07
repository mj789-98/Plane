using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5.0f; // Adjust the move speed as needed
	public float smoothness = 0.5f; // Adjust the smoothness of the movement


	private Vector3 targetPosition;
	private Rigidbody characterBody;
	private float ScreenWidth;
	private Animator animator;
	private new ParticleSystem particleSystem;
	public GameObject character;
	private Shooter shootButton;
	

	void Start()
	{
		ScreenWidth = Screen.width;
		characterBody = character.GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		particleSystem = GetComponent<ParticleSystem>();
		// Get the touch information


		shootButton = GameObject.FindObjectOfType<Shooter>();
	}

	private void Update()
	{
		HandleInput();
		
	}
	private void ResetAnimationTrigger()
	{
		
		// Reset the animation trigger after 3 seconds
		animator.SetBool("isIdle", false); // Assuming "IsIdle" is the parameter for your animation
	}

	private void HandleInput()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// Check if the touch is over UI
			if (!IsPointerOverUIObject(Input.GetTouch(0).position))
			{
				// Get the touch position
				Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 15));

				// Set the target position for smooth movement
				targetPosition = touchPos;
				if (Input.GetTouch(0).position.x < Screen.width / 2)
				{
					
					// Play the animation for the back half of the screen
					// Replace "YourAnimationTriggerName" with the actual trigger name of your animation
					animator.SetTrigger("isIdle");
					//animator.SetBool("IsIdle", true); // Assuming "IsIdle" is the parameter for your animation
					Invoke("ResetAnimationTrigger", 3f); // Reset the animation trigger after 3 seconds
				}

			}

			
		}

		// Smoothly move the player towards the target position
		transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
	}
	

	private bool IsPointerOverUIObject(Vector2 touchPosition)
	{
		// Convert the touch position to a PointerEventData
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = touchPosition;

		// Check if there is any UI object under the touch
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

		// Return true if UI object is found, otherwise false
		return results.Count > 0;
	}
}
