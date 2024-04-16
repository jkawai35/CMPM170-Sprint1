using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component

        // Spawn enemy at a random position on the map
        transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
    }

    void Update()
    {
        // Calculate direction towards the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = new Vector2(direction.x, direction.y);

        // Check if enemy needs to be flipped
        if (movement.x < 0)
        {
            // Facing left
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            // Facing right
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        // Move the enemy towards the player
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }
}
