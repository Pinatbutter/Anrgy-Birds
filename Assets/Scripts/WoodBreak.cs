using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBreak : MonoBehaviour
{
    public GameObject bigWood;
    public GameObject woodPiece1;
    public GameObject woodPiece2;

    public int hitPoints = 2;

    private bool broken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints == 0)
        {
            broken = true;
        }

        if (broken == true)
        {
            breakdown();
        }
    }

    void breakdown()
    {
        bigWood.SetActive(false);
        woodPiece1.transform.position = (bigWood.transform.position) + Vector3.up;
        woodPiece1.transform.rotation = (bigWood.transform.rotation);
        woodPiece1.SetActive(true);
        woodPiece2.transform.position = (bigWood.transform.position) + Vector3.down;
        woodPiece2.transform.rotation = (bigWood.transform.rotation);
        woodPiece2.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.relativeVelocity;
        if (velocity.magnitude > 10 && bigWood.activeSelf == true)
        {
            if(hitPoints > 0)
            {
                hitPoints--;
            }

        }

    }

}
