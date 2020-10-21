using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWallScript : MonoBehaviour
{
    static private movingWallScript w;
    public float verticalSpeed;
    void Awake()
    {
        w = this;
    }
    void Start()
    {

    }
    void Update()
    {
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
    }
}
