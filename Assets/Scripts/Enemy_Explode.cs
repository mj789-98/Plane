using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Explode : MonoBehaviour
{
    public GameObject blue;
    public AudioSource audioSource;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_Plane")
        {
            blue.SetActive(true);
            audioSource.Play();

        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Blue_Meteor")
        {
            blue.SetActive(false);
        }
    }

}
