using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float leftMost;
    public float rightMost;
    public int speed;

    Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        RB.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(RB.position.x > rightMost) {
            RB.velocity = new Vector2(-speed, 0);
        } else if(RB.position.x < leftMost) {
            RB.velocity = new Vector2(speed, 0);
        }
    }
}
