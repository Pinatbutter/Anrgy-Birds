using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosionEffect;
    public float power = 100.0f;
    public float radius = 10.0f;
    public float upForce = 1.0f;
    public float fuse = 10.0f;
    private bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !hasExploded)
        {
            Invoke("Detonate", fuse);
            hasExploded = true;
        }

    }

    void Detonate()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}
