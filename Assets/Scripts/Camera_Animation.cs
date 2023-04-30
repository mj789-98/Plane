using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Animation : MonoBehaviour
{
   
    public Animator animator;
    public string animationBool = "GameStarts";

    void Start()
    {
        animator.SetBool(animationBool, true);
    }
}


