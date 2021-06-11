using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpHeight;

    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }

        if (transform.position.y > 10)
        {
            GameOver();
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver()
    {
        rb.velocity = Vector2.zero;
        OnPlayerDeath();
        GetComponent<Player>().enabled = false;
    }
}
