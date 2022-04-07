using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject successScreen;
    public GameObject explosion;
    Rigidbody2D RB;
    BoxCollider2D BC;
    Animator AN;
    AudioSource jumpSound;
    AudioSource explosionSound;
    public int jumpSpeed;
    public bool isGrounded;

    Touch touch;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        BC = GetComponent<BoxCollider2D>();
        AN = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
        explosionSound = explosion.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        MaintainPosition();

        // if(Input.touchCount > 0) {
        //     touch = Input.GetTouch(0);
        //     Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //     if((touchPosition.y < 2 || touchPosition.x > -2) && Input.GetMouseButtonDown(0) && isGrounded) {
        //         Jump();
        //         isGrounded = false;
        //         jumpSound.Play();
        //         AN.Play("Jump");
        //     }
        // }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
            isGrounded = false;
            jumpSound.Play();
            AN.Play("Jump");
        } else if(Input.GetKeyDown(KeyCode.Q)) {
            SwitchRed();
        } else if(Input.GetKeyDown(KeyCode.W)) {
            SwitchGreen();
        } else if(Input.GetKeyDown(KeyCode.E)) {
            SwitchBlue();
        }
    }

    void Jump() {
        RB.velocity = new Vector2(RB.velocity.x, jumpSpeed);
    }

    void MaintainPosition() {
        RB.velocity = new Vector2(0, RB.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collided) {
        if(collided.gameObject.CompareTag("Jumpable")) {
            isGrounded = true;
            AN.Play("Player");
        }

        if(collided.gameObject.CompareTag("Spike")) {
            Time.timeScale = 0;
            collided.gameObject.GetComponent<AudioSource>().Play();
            deathScreen.SetActive(true);
        }
        else if(collided.gameObject.CompareTag("Finish")) {
            Time.timeScale = 0;
            collided.gameObject.GetComponent<AudioSource>().Play();
            successScreen.SetActive(true);
        }
    }

    void Switch(int layer) {
        Color color;
        if(layer == 0) {
            color = Color.white;
        } else {
            layer += 10;
            if(layer == 11) {
                color = Color.red;
            } else if(layer == 12) {
                color = Color.green;
            } else {
                color = Color.blue;
            }
        }
        transform.GetComponent<SpriteRenderer>().color = color;
        explosion.transform.GetComponent<SpriteRenderer>().color = color;

        gameObject.layer = layer;
        float range = 0.05F * Random.Range(0, 4);
        explosionSound.pitch = 1 + range;
        explosionSound.Play();
        explosion.SetActive(true);
        Invoke("DisableExplosion", 0.5F);
    }

    void SwitchDefault() { // Butonlar için ayrı fonksiyonlar yazıldı
        Switch(0);
    }

    public void SwitchRed() {
        Switch(1);
    }

    public void SwitchGreen() {
        Switch(2);
    }

    public void SwitchBlue() {
        Switch(3);
    }

    public void DisableExplosion() {
        explosion.SetActive(false);
    }

    // public void TouchJump() { // Diğer renk tuşları ile beraber çalışmasını önleyen buton fonksiyonu
    //     touchJump = true;
    // }
}
