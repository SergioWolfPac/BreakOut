using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool MoveUp;
    public Rigidbody2D rb;
    public int damage;

    Vector2 movement = new Vector2(0, 1);

    private void FixedUpdate()
    {
        if (MoveUp)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position - movement * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turn")
        {
            MoveUp = true;
        }
        else if (collision.tag == "Turn2")
        {
            MoveUp = false;
        }
        else if (collision.tag == "Player")
        {
            Debug.Log("Enemy hit the Player");

            collision.GetComponent<PlayerMovement>().damage(this.damage);
        }
    }
}
