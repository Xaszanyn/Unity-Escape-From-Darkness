using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float backgroundSpeed;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-backgroundSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
