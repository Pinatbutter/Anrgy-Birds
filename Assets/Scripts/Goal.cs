using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{
    // A static field accessible by code anywhere
    static public bool goalMet = false;
    public float pigPop = 7.0f;
    public GameObject popEffect;
    public GameObject porker;

    //  This is commented out because this makes it to where a projectile simply has to 
    //  touch the pig without any applied force.

    //void OnTriggerEnter(Collider other)
    //{
    //    // When the trigger is hit by something
    //    // Check to see if it's a Projectile
    //    if (other.gameObject.tag == "Projectile")
    //    {
    //        // If so, set goalMet to true
    //        Goal.goalMet = true;
    //        Instantiate(popEffect, transform.position, transform.rotation);
    //        Destroy(porker);
    //    }
    //}

    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.relativeVelocity;
        if (velocity.magnitude > pigPop)
        {
            //Goal.goalMet = true;
            Instantiate(popEffect, transform.position, transform.rotation);
            Destroy(porker);
        }

    }

    public static void checkPigs()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Goal");
        if (gameObjects.Length == 0)
        {
            Goal.goalMet = true;
        }
    }

}
