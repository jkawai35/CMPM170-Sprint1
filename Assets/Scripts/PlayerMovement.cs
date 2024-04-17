using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public CoinManager cm;
    public Upgrade upgrade;

    bool isMoving;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
 
    }

    void Update()
    {
        if (!isMoving)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();

            rb2d.velocity = moveInput * moveSpeed;

            if (moveInput != Vector2.zero)
            {
                animator.SetFloat("moveX", moveInput.x);
                animator.SetFloat("moveY", moveInput.y);
                isMoving = true;
            }

            animator.SetBool("isMoving", isMoving);
        }
        
        isMoving = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            Destroy(other.gameObject);

            //adjust multiplier and money values
            //money value can be changed
            upgrade.multiplier += (float)0.5;
            upgrade.money += 100;
        }
    }
}
