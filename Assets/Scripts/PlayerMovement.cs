using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static bool solvingPuzzle = false;

    public float moveSpeed = 5f;
    public float hitDelay = 2f;

    public Rigidbody2D rb;
    public Animator animator;
    public Text keyText;
    public Text hpText;

    public static int keys = 0;
    public int health = 100;
    public int maxHealth = 100;
    
    Vector2 movement;

    private float nextHit;

    public HealthBar healthBar;

    void Start()
    {
        nextHit = Time.time;
        keyText.text = "x " + keys;
        hpText.text = ": " + health;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 characterScale = transform.localScale;

        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement
        if (!solvingPuzzle) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        hpText.text = ": " + health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Key")
        {
            keys++;
            Debug.Log("Player has " + keys + " keys");
            keyText.text = "x " + keys;
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "Enemy")
        {
            Debug.Log("Player hit the Enemy");
        }
    }

    public void damage(int dmg)
    {
        if (Time.time >= nextHit)
        {
            health -= dmg;
            hpText.text = ": " + health;
            healthBar.SetHealth(health);

            nextHit = Time.time + hitDelay;
        }
    }
}
