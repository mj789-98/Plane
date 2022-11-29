using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    //variables    
    public float moveSpeed = 300;
    public GameObject character;
    private Rigidbody characterBody;
    private float ScreenWidth;
    private Animator animator;
    ParticleSystem particleSystem;
    // Use this for initialization    
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame    
    void Update()
    {
        int i = 0;
        //loop over every touch found    
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right    
                RunCharacter(1.0f);
                animator.SetBool("isIdle", true);
                particleSystem.Play();

            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left    
                RunCharacter(-1.0f);
                animator.SetBool("isIdle", false);
                particleSystem.Stop(); 

            }
           
            ++i;
        }
    }
    void FixedUpdate()
    {
#if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
#endif
    }
    private void RunCharacter(float horizontalInput)
    {
        //move player    
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
    }
}