using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collided) {
        if(!collided.gameObject.CompareTag("Floor")) Destroy(collided.gameObject);
    }
}
