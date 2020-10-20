using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWood : MonoBehaviour
{

    public int hitPoints = 1;

    public GameObject woodPiece1;

    // Update is called once per frame
    void Update()
    {
        if (hitPoints == 0)
        {
            Destroy(woodPiece1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.relativeVelocity;
        if (velocity.magnitude > 10)
        {
            if (hitPoints > 0)
            {
                hitPoints--;
            }

        }

    }
}
